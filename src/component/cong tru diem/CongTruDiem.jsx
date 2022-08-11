import React, { useEffect, useRef, useState } from "react";
import {
  Input,
  Button,
  Space,
  Table,
  Pagination,
  Modal,
  DatePicker,
  Select,
  message,
  Upload,
  Row,
  Col,
  Spin,
  Popconfirm,
  Empty,
  Alert,
} from "antd";
import moment from "moment";
import {
  UserOutlined,
  SearchOutlined,
  UploadOutlined,
  EditFilled,
  DeleteFilled,
} from "@ant-design/icons";
import "./CongTruDiem.scss";
import Highlighter from "react-highlight-words";
import { hover } from "@testing-library/user-event/dist/hover";
import MenuProjectManage from "../menu/Menu";
import Axios from "axios";
import axios from "axios";

const props = {
  name: "file",
  action: "https://www.mocky.io/v2/5cc8019d300000980a055e76",
  headers: {
    authorization: "authorization-text",
  },

  onChange(info) {
    if (info.file.status !== "uploading") {
      console.log(info.file, info.fileList);
    }

    if (info.file.status === "done") {
      message.success(`${info.file.name} file uploaded successfully`);
    } else if (info.file.status === "error") {
      message.error(`${info.file.name} file upload failed.`);
    }
  },
};

const onSearch = (value) => console.log(value);
// const onSearch = (value) => datas.filter(item => {
//   if (value == '') {
//     return item
//   } else if (item.name.toLowerCase().includes(inputSearch.toLowerCase()))
//     {
//       return item;
//     }
//   }
// }).map

function CongTruDiem() {
  const { Option } = Select;
  const { Search } = Input;
  const [searchText, setSearchText] = useState("");
  const [searchedColumn, setSearchedColumn] = useState("");
  const searchInput = useRef(null);
  const [visible, setVisible] = useState(false);
  const [visible2, setVisible2] = useState(false);
  const [visible3, setVisible3] = useState(false);
  const [visible4, setVisible4] = useState(false);
  const { RangePicker } = DatePicker;
  const [datas, setDatas] = useState([]);
  const [datas1, setDatas1] = useState({});
  const [datas2, setDatas2] = useState({});
  const [loading, setloading] = useState(true);

  const [importer, setImporter] = useState("Ad");
  const [point, setPoint] = useState("");
  const [note, setNote] = useState("");
  const [dateAdded, setDateAdded] = useState();
  const [date, setDate] = useState();
  const [type, setType] = useState("CONG");
  const [money, setMoney] = useState("");
  const [shop, setShop] = useState("");
  const [reason, setReason] = useState("");
  const [disabled, setDisabled] = useState("");
  const [disabled1, setDisabled1] = useState("disabled");

  useEffect(() => {
    getData();

    return () => {};
  }, []);

  const getData = async () => {
    await axios
      .get("https://localhost:7145/api/ValidPoints/GetAccumulatePointList")
      .then((res) => {
        setloading(false);
        setDatas(
          res.data.data.map((row) => ({
            id: row.id,
            ngay: row.date === null ? "-" : row.date,
            sophieu: row.id,
            lydo: row.reason === null ? "-" : row.reason,
            ttv: row.memberCards === null ? "-" : row.memberCards,
            chinhsach:
              row.accumulatePointsRules === null
                ? "-"
                : row.accumulatePointsRules,
            diem: row.points === null ? "-" : row.points,
            cuahang: row.shop === null ? "-" : row.shop,
            nguoinhap: row.importer === null ? "-" : row.importer,
            loai: row.type === null ? "-" : row.type,
            ghichu: row.note === null ? "-" : row.note,
            sua: (
              <EditFilled
                style={{ color: "#3e588c", fontSize: "20px" }}
                onClick={() => showModal4(row.id)}
              />
            ),
            xoa: (
              <Popconfirm
                title="Sure to delete?"
                onConfirm={() => onCongTruDiem(row.id)}
              >
                <DeleteFilled
                  key={row.id}
                  style={{ color: "#0D378C", fontSize: "20px" }}
                />
              </Popconfirm>
            ),
          }))
        );
      });
  };

  const getSoThe = (sothe) => {
    axios
      .get(
        `https://localhost:7145/api/MemberCard/SearchMemberCardToAddPoint/${sothe}`
      )
      .then((res) => {
        if (res.data.data === null) {
          message.error("Mã thẻ sai");
          setDatas1({
            type: "",
            validDate: "",
            customer: {
              companyName: "",
              customerName: "",
              province: "",
            },
          });
        } else {
          setDatas1(res.data.data);
        }
      });
  };

  const onSearch = (value) => {
    if (value == "") {
      getData();
    } else {
      axios
        .get(
          `https://localhost:7145/api/ValidPoints/SearchAccumulatePoint/${value}`
        )
        .then((res) => {
          console.log(res.data.success);
          if (res.data.data === null) {
            setDatas([]);
          } else {
            setloading(false);
            setDatas(
              res.data.data.map((row) => ({
                id: row.id,
                ngay: row.date === null ? "-" : row.date,
                sophieu: row.id,
                lydo: row.reason === null ? "-" : row.reason,
                ttv: row.memberCards === null ? "-" : row.memberCards,
                chinhsach:
                  row.accumulatePointsRules === null
                    ? "-"
                    : row.accumulatePointsRules,
                diem: row.points === null ? "-" : row.points,
                cuahang: row.shop === null ? "-" : row.shop,
                nguoinhap: row.importer === null ? "-" : row.importer,
                loai: row.type === null ? "-" : row.type,
                ghichu: row.note === null ? "-" : row.note,
                sua: (
                  <EditFilled style={{ color: "#3e588c", fontSize: "20px" }} />
                ),
                xoa: (
                  <Popconfirm
                    title="Sure to delete?"
                    onConfirm={() => onCongTruDiem(row.id)}
                  >
                    <DeleteFilled
                      key={row.id}
                      style={{ color: "#0D378C", fontSize: "20px" }}
                    />
                  </Popconfirm>
                ),
              }))
            );
          }
        });
    }
  };

  const showModal = () => {
    setVisible(true);
  };

  const handleOk = () => {
    setVisible(false);
  };

  const handleCancel = () => {
    setVisible(false);
  };

  const showModal4 = (id) => {
    setVisible4(true);
    getDataToModalUpdate(id);
  };

  const handleOk4 = () => {
    setTimeout(setVisible4(false), 3000);
    handleUpdate();
  };

  const handleCancel4 = () => {
    setVisible4(false);
  };

  const showModal2 = () => {
    setVisible2(true);
  };

  const handleOk2 = (e) => {
    setTimeout(setVisible2(false), 3000);
    addData();
  };

  const handleCancel2 = () => {
    setVisible2(false);
  };

  const showModal3 = () => {
    setVisible3(true);
  };

  const handleOk3 = () => {
    setVisible3(false);
  };

  const handleCancel3 = () => {
    setVisible3(false);
  };

  const onChange = (dates, dateStrings) => {
    if (dates) {
      console.log("From: ", dates[0], ", to: ", dates[1]);
      console.log("From: ", dateStrings[0], ", to: ", dateStrings[1]);
    } else {
      console.log("Clear");
    }
  };

  const onChange2 = (date, dateString) => {
    console.log(date, dateString);
  };

  const handleSearch = (selectedKeys, confirm, dataIndex) => {
    confirm();
    setSearchText(selectedKeys[0]);
    setSearchedColumn(dataIndex);
  };

  const handleReset = (clearFilters) => {
    clearFilters();
    setSearchText("");
  };
  const getColumnSearchProps = (dataIndex) => ({
    filterDropdown: ({
      setSelectedKeys,
      selectedKeys,
      confirm,
      clearFilters,
    }) => (
      <div
        style={{
          padding: 8,
        }}
      >
        <Input
          ref={searchInput}
          placeholder={`Search ${dataIndex}`}
          value={selectedKeys[0]}
          onChange={(e) =>
            setSelectedKeys(e.target.value ? [e.target.value] : [])
          }
          onPressEnter={() => handleSearch(selectedKeys, confirm, dataIndex)}
          style={{
            marginBottom: 8,
            display: "block",
          }}
        />
        <Space>
          <Button
            type="primary"
            onClick={() => handleSearch(selectedKeys, confirm, dataIndex)}
            icon={<SearchOutlined />}
            size="small"
            style={{
              width: 90,
            }}
          >
            Search
          </Button>
          <Button
            onClick={() => clearFilters && handleReset(clearFilters)}
            size="small"
            style={{
              width: 90,
            }}
          >
            Reset
          </Button>
          <Button
            type="link"
            size="small"
            onClick={() => {
              confirm({
                closeDropdown: false,
              });
              setSearchText(selectedKeys[0]);
              setSearchedColumn(dataIndex);
            }}
          >
            Filter
          </Button>
        </Space>
      </div>
    ),
    filterIcon: (filtered) => (
      <SearchOutlined
        style={{
          color: filtered ? "#1890ff" : undefined,
        }}
      />
    ),
    onFilter: (value, record) =>
      record[dataIndex].toString().toLowerCase().includes(value.toLowerCase()),
    onFilterDropdownVisibleChange: (visible) => {
      if (visible) {
        setTimeout(() => searchInput.current?.select(), 100);
      }
    },
    render: (text) =>
      searchedColumn === dataIndex ? (
        <Highlighter
          highlightStyle={{
            backgroundColor: "#ffc069",
            padding: 0,
          }}
          searchWords={[searchText]}
          autoEscape
          textToHighlight={text ? text.toString() : ""}
        />
      ) : (
        text
      ),
  });

  const columns = [
    {
      title: "Ngày",
      dataIndex: "ngay",
      key: "ngay",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Số phiếu",
      dataIndex: "sophieu",
      key: "sophieu",
      width: "10%",
      sorter: (a, b) => a.sophieu - b.sophieu,
    },
    {
      title: "Lý do",
      dataIndex: "lydo",
      key: "lydo",
      width: "10%",
      sorter: (a, b) => a.lydo.localeCompare(b.lydo),
    },
    {
      title: "Thẻ thành viên",
      dataIndex: "ttv",
      key: "ttv",
      width: "10%",
      sorter: (a, b) => a.ttv.localeCompare(b.ttv),
    },
    {
      title: "Chính sách",
      dataIndex: "chinhsach",
      key: "chinhsach",
      width: "10%",
      sorter: (a, b) => a.chinhsach.localeCompare(b.chinhsach),
    },
    {
      title: "Điểm",
      dataIndex: "diem",
      key: "diem",
      width: "10%",
      sorter: (a, b) => a.diem - b.diem,
    },
    {
      title: "Cửa hàng",
      dataIndex: "cuahang",
      key: "cuahang",
      width: "10%",
      sorter: (a, b) => a.cuahang.localeCompare(b.cuahang),
    },
    {
      title: "Người nhập",
      dataIndex: "nguoinhap",
      key: "nguoinhap",
      width: "10%",
      sorter: (a, b) => a.nguoinhap.localeCompare(b.nguoinhap),
    },
    {
      title: "Loại",
      dataIndex: "loai",
      key: "loai",
      width: "10%",
      sorter: (a, b) => a.loai.localeCompare(b.loai),
    },
    {
      title: "Ghi chú",
      dataIndex: "ghichu",
      key: "ghichu",
      width: "10%",
      sorter: (a, b) => a.ghichu.localeCompare(b.ghichu),
    },
    {
      title: "Sửa",
      dataIndex: "sua",
      key: "sua",
      width: "5%",
    },
    {
      title: "Xóa",
      dataIndex: "xoa",
      key: "xoa",
      width: "5%",
    },
  ];

  const addData = async () => {
    const dataCTD = {
      date: date,
      reason: reason,
      memberCards: {
        cardNumber: datas1.cardNumber,
      },
      type: type,
      money: money,
      points:
        point == 0
          ? parseInt(money / 100).toString()
          : parseInt(point).toString(),
      shop: "",
      dateAdded: dateAdded,
      importer: importer,
      note: note,
    };
    await axios.post(
      `https://localhost:7145/api/ValidPoints/CreateAccumulatePoint`,
      dataCTD
    );
    setDatas([dataCTD, ...datas]);
    getData();
    if (dataCTD !== "{}") {
      message.success("Thêm thành công");
      setMoney("");
      setPoint("");
      setNote("");
      setDatas1({});
      setDate(new Date());
      setReason("");
    }
  };

  const onCongTruDiem = (id) => {
    axios
      .delete(
        `https://localhost:7145/api/ValidPoints/DeleteAccumulatePoint/${id}`
      )
      .then(() => {
        getData();
      });
  };

  const getDataToModalUpdate = (id) => {
    axios
      .get(`https://localhost:7145/api/ValidPoints/GetPointById/${id}`)
      .then((res) => {
        setDatas2(res.data.data);
      });
  };

  const handleUpdate = async () => {
    const updateCTD = {
      importer: datas2.importer,
      id: datas2.id,
      memberCards: {
        cardNumber: datas2.memberCards.cardNumber,
      },
      date: date,
      reason: reason,
      type: datas2.type,
      money: money,
      points:
        point == 0
          ? parseInt(money / 100).toString()
          : parseInt(point).toString(),
      shop: "",
      note: note,
    };
    await axios.put(
      `https://localhost:7145/api/ValidPoints/UpdateAccumulatePoint`,
      updateCTD
    );
    setDatas([updateCTD, ...datas]);
    console.log(updateCTD);
    getData();
    if (updateCTD !== "{}") {
      message.success("Chỉnh sửa thành công");
      setMoney("");
      setPoint("");
      setNote("");
      setDatas1({});
      setDate(new Date());
      setReason("");
    }
  };

  const handleTypeChange = (value) => {
    if (value === "TRU") {
      setDisabled("disabled");
      setDisabled1("");
    } else {
      setDisabled("");
      setDisabled1("disabled");
    }
  };

  console.log(datas2)

  return (
    <>
      <Row id="CSTDRowContainer">
        <Col span={21} id="CTDColContainer">
          <div id="Container">
            <Search
              placeholder="input search text"
              onSearch={onSearch}
              style={{ width: 200 }}
            />
            <Button type="primary" onClick={showModal}>
              Tìm kiếm
            </Button>
            <Modal
              width={"770px"}
              title="TÌM KIẾM"
              centered
              visible={visible}
              onOk={handleOk}
              onCancel={handleCancel}
              footer={[
                <Button key="back" onClick={handleCancel}>
                  Hủy
                </Button>,
                <Button key="submit" type="primary" onClick={handleOk}>
                  Tìm
                </Button>,
              ]}
            >
              <div>
                <span id="chonNgay">Chọn ngày</span>
                <RangePicker
                  ranges={{
                    Today: [moment(), moment()],
                    "This Month": [
                      moment().startOf("month"),
                      moment().endOf("month"),
                    ],
                  }}
                  onChange={onChange}
                />
              </div>
              <div>
                <span id="soThe">Số thẻ thành viên</span>
                <Input placeholder="Nhập số thẻ" />
              </div>
              <div>
                <span id="khachHang">Khách hàng</span>
                <Input id="nhapKhachHang" placeholder="Nhập tên khách hàng" />
              </div>
            </Modal>
            <Button type="primary" onClick={showModal2}>
              Thêm mới
            </Button>
            <Modal
              width={"1200px"}
              title="ĐIỀU CHỈNH ĐIỂM"
              centered
              visible={visible2}
              onOk={handleOk2}
              onCancel={handleCancel2}
              footer={[
                <Button key="back" onClick={handleCancel2}>
                  Hủy
                </Button>,
                <Button key="submit" type="primary" onClick={handleOk2}>
                  Thêm
                </Button>,
              ]}
            >
              <div class="inputFormDieuChinh">
                <span class="inputText">Số phiếu</span>
                <Input disabled />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Ngày</span>
                <input
                  value={date}
                  style={{
                    backgroundColor: "#0d378c",
                    border: "1px solid #FFF",
                    borderRadius: "4px",
                    marginLeft: "256px",
                    fontSize: "14px",
                    height: "30px",
                    color: "#FFF",
                    padding: "0 12px",
                  }}
                  type="date"
                  onChange={(e) => setDate(e.target.value)}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Lý do cộng trừ</span>
                <Input
                  placeholder="nhập lý do cộng trừ"
                  value={reason}
                  onChange={(e) => setReason(e.target.value)}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Số thẻ</span>
                <Search
                  placeholder="nhập thẻ thành viên"
                  onSearch={getSoThe}
                  style={{ width: 200 }}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Loại thẻ</span>
                <Input
                  value={datas1.type === "" ? "-" : datas1.type}
                  disabled
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">HL đến</span>
                <Input
                  value={datas1.validDate === "" ? "-" : datas1.validDate}
                  disabled
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Công ty</span>
                <Input
                  value={
                    JSON.stringify(datas1) === "{}"
                      ? ""
                      : datas1.customer.companyName ||
                        (datas1.customer.companyName === ""
                          ? "-"
                          : datas1.customer.companyName)
                  }
                  disabled
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Khách hàng</span>
                <Input
                  value={
                    JSON.stringify(datas1) === "{}"
                      ? ""
                      : datas1.customer.customerName ||
                        (datas1.customer.customerName === ""
                          ? "-"
                          : datas1.customer.customerName)
                  }
                  disabled
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Tỉnh</span>
                <Input
                  value={
                    JSON.stringify(datas1) === "{}"
                      ? ""
                      : datas1.customer.province ||
                        (datas1.customer.province === "" ||
                        datas1.customer.province === null
                          ? "-"
                          : datas1.customer.province)
                  }
                  disabled
                />
              </div>
              <div id="loai">
                <span>Loại</span>
                <Select
                  defaultValue={type}
                  style={{ width: 120, marginLeft: "265px" }}
                  onChange={handleTypeChange}
                >
                  <Option value="CONG">CỘNG</Option>
                  <Option value="TRU">TRỪ</Option>
                </Select>
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Số tiền</span>
                <Input
                  value={money}
                  disabled={disabled}
                  onChange={(e) => setMoney(e.target.value)}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Điểm</span>
                <Input
                  value={point}
                  placeholder={money / 100}
                  onChange={(e) => setPoint(e.target.value)}
                  disabled={disabled1}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Shop</span>
                <Input disabled onChange={(e) => setShop(e.target.value)} />
              </div>
              <div id="audit">
                <div class="inputFormDieuChinh">
                  <span class="inputText">Ngày sửa</span>
                  <Input disabled />
                </div>
                <div class="inputFormDieuChinh">
                  <span class="inputText">Người nhập</span>
                  <Input disabled />
                </div>
                <div class="inputFormDieuChinh">
                  <span class="inputText">Ghi chú</span>
                  <Input
                    onChange={(e) => setNote(e.target.value)}
                  />
                </div>
              </div>
            </Modal>
            <Modal
              width={"1200px"}
              title="ĐIỀU CHỈNH ĐIỂM"
              centered
              visible={visible4}
              onOk={handleOk4}
              onCancel={handleCancel4}
              footer={[
                <Button key="back" onClick={handleCancel4}>
                  Hủy
                </Button>,
                <Button key="submit" type="primary" onClick={handleOk4}>
                  Sửa
                </Button>,
              ]}
            >
              <div class="inputFormDieuChinh">
                <span class="inputText">Số phiếu</span>
                <Input value={datas2.id} disabled />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Ngày</span>
                <input
                  value={date}
                  style={{
                    backgroundColor: "#0d378c",
                    border: "1px solid #FFF",
                    borderRadius: "4px",
                    marginLeft: "256px",
                    fontSize: "14px",
                    height: "30px",
                    color: "#FFF",
                    padding: "0 12px",
                  }}
                  type="date"
                  onChange={(e) => setDate(e.target.value)}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Lý do cộng trừ</span>
                <Input
                  placeholder="nhập lý do cộng trừ"
                  value={reason}
                  onChange={(e) => setReason(e.target.value)}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Số thẻ</span>
                <Input
                  value={
                    JSON.stringify(datas2) === "{}"
                      ? ""
                      : datas2.memberCards.cardNumber
                  }
                  disabled
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Loại thẻ</span>
                <Input disabled />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">HL đến</span>
                <Input disabled />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Công ty</span>
                <Input disabled />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Khách hàng</span>
                <Input
                  value={
                    JSON.stringify(datas2) === "{}"
                      ? ""
                      : datas2.memberCards.customer.customerName
                  }
                  disabled
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Tỉnh</span>
                <Input disabled />
              </div>
              <div id="loai">
                <span>Loại</span>
                <Select
                  value={datas2.type}
                  style={{ width: 120, marginLeft: "265px" }}
                  disabled
                >
                  <Option value="CONG">CỘNG</Option>
                  <Option value="TRU">TRỪ</Option>
                </Select>
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Số tiền</span>
                <Input
                  value={money}
                  onChange={(e) => setMoney(e.target.value)}
                  disabled={datas2.type === "TRU" ? disabled1 : disabled}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Điểm</span>
                <Input
                  value={point}
                  placeholder={money / 100}
                  onChange={(e) => setPoint(e.target.value)}
                  disabled={datas2.type === "TRU" ? disabled : disabled1}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Shop</span>
                <Input disabled onChange={(e) => setShop(e.target.value)} />
              </div>
              <div id="audit">
                <div class="inputFormDieuChinh">
                  <span class="inputText">Ngày sửa</span>
                  <Input value={datas2.dateAdded} disabled />
                </div>
                <div class="inputFormDieuChinh">
                  <span class="inputText">Người nhập</span>
                  <Input value={importer} disabled />
                </div>
                <div class="inputFormDieuChinh">
                  <span class="inputText">Ghi chú</span>
                  <Input
                    value={note}
                    onChange={(e) => setNote(e.target.value)}
                  />
                </div>
              </div>
            </Modal>
            <Button type="primary" onClick={showModal3}>
              Nhập từ excel
            </Button>
            <Modal
              className="modalExcel"
              width={"770px"}
              title="NHẬP EXCEL"
              centered
              visible={visible3}
              onOk={handleOk3}
              onCancel={handleCancel3}
              footer={[
                <Button key="">Download template</Button>,
                <Button key="submit" type="primary" onClick={handleOk3}>
                  Lưu
                </Button>,
              ]}
            >
              <div id="dragExcel">
                <Upload.Dragger {...props}>
                  <UploadOutlined />
                  <p>Drag & Drop to Upload File Here</p>
                  <p>OR</p>
                  <Button>Browse File</Button>
                </Upload.Dragger>
              </div>
            </Modal>
            <UserOutlined />
          </div>
          <h2 id="titleCongTruDiem">CỘNG / TRỪ ĐIỂM</h2>
          {loading ? (
            <Spin size="large" />
          ) : (
            <Table
              columns={columns}
              dataSource={datas}
              pagination={{ position: ["bottomLeft"] }}
            />
          )}
        </Col>
      </Row>
    </>
  );
}

export default CongTruDiem;
