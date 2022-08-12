import React, { useEffect, useRef, useState } from "react";
import Axios from "axios";
import {
  Input,
  Button,
  Space,
  Table,
  DatePicker,
  Modal,
  Row,
  Col,
  Spin,
  Checkbox,
  Form,
  message,
  Popconfirm,
} from "antd";
import {
  UserOutlined,
  SearchOutlined,
  DeleteFilled,
  EditFilled,
} from "@ant-design/icons";
import "./TheThanhVien.scss";
import Highlighter from "react-highlight-words";
import moment from "moment";
import axios from "axios";

function TheThanhVien() {
  const [searchText, setSearchText] = useState("");
  const [searchedColumn, setSearchedColumn] = useState("");
  const searchInput = useRef(null);
  const { Search } = Input;
  const [visible, setVisible] = useState(false);
  const [visible2, setVisible2] = useState(false);
  const [datas, setDatas] = useState([]);
  const [loading, setloading] = useState(true);

  const [cardNumber, setCardNumber] = useState("");
  const [reason, setReason] = useState("");
  const [issueDate, setIssueDate] = useState("");
  const [validDate, setValidDate] = useState("");
  const [effectDate, setEffectDate] = useState("");

  const [idEdit, setIdEdit] = useState("");
  const [cardNumberEdit, setCardNumberEdit] = useState("");
  const [reasonEdit, setReasonEdit] = useState("");
  const [validDateEdit, setValidDateEdit] = useState();
  const [effectDateEdit, setEffectDateEdit] = useState();
  const [issueDateEdit, setIssueDateEdit] = useState();
  const [customerName, setCustomerName] = useState("");
  const [importer, setImporter] = useState("");
  const [registerAt, setRegisterAt] = useState("KNS");
  const [dateAdded, setDateAdded] = useState();

  useEffect(() => {
    getData();
  }, []);

  const onSearch = (value) => {
    if (value == "") {
      getData();
    } else {
      axios
        .get(`https://localhost:7145/api/MemberCard/SearchMemberCard/${value}`)
        .then((res) => {
          console.log(res.data.success);
          if (res.data.data === null) {
            setDatas([]);
          } else {
            setloading(false);
            setDatas(
              res.data.data.map((row) => ({
                id: row.id,
                sothe: row.cardNumber,
                loaithe: row.type,
                ngaybanhanh: row.dateAdded === null ? "-" : row.dateAdded,
                lydophathanh: row.reason,
                hieuluctu: row.validDate === null ? "-" : row.validDate,
                hieulucden: row.effectDate === null ? "-" : row.effectDate,
                active:
                  row.isActive === true ? (
                    <Popconfirm
                      title="Inactive this?"
                      onConfirm={() => console.log("hi")}
                    >
                      <Checkbox style={{ marginLeft: "18px" }} defaultChecked />
                    </Popconfirm>
                  ) : (
                    <Popconfirm
                      title="Active this?"
                      onConfirm={() => console.log("hi")}
                    >
                      <Checkbox
                        style={{ marginLeft: "18px" }}
                        defaultChecked={false}
                      />
                    </Popconfirm>
                  ),
                khachhang: row.customer === null ? "-" : row.customer,
                dangkytai: row.registerAt === null ? "-" : row.registerAt,
                nguoinhap: row.importer,
                sua: (
                  <EditFilled style={{ color: "#3e588c", fontSize: "20px" }} />
                ),
                xoa: (
                  <Popconfirm
                    id="TTVConfirm"
                    title="Sure to delete?"
                    onConfirm={() => onDeleteKhachHang(row.id)}
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

  const getData = async () => {
    await Axios.get("https://localhost:7145/api/MemberCard/GetAllMembers").then(
      (res) => {
        setloading(false);
        setDatas(
          res.data.data.map((row) => ({
            id: row.id,
            sothe: row.cardNumber,
            loaithe: row.type,
            ngaybanhanh: row.issueDate === null ? "-" : row.issueDate,
            lydophathanh: row.reason,
            hieuluctu: row.effectDate === null ? "-" : row.effectDate,
            hieulucden: row.validDate === null ? "-" : row.validDate,
            active:
              row.isActive === true ? (
                <Popconfirm
                  title="Active this?"
                  onConfirm={(id) => inActiveMemberCard(row.id)}
                >
                  <Checkbox style={{ marginLeft: "18px" }} defaultChecked />
                </Popconfirm>
              ) : (
                <Popconfirm
                  title="Inactive this?"
                  onConfirm={(id) => inActiveMemberCard(row.id)}
                >
                  <Checkbox
                    style={{ marginLeft: "18px" }}
                    defaultChecked={false}
                  />
                </Popconfirm>
              ),
            khachhang: row.customer === null ? "-" : row.customer,
            dangkytai: row.registerAt === null ? "-" : row.registerAt,
            nguoinhap: row.importer,
            sua: (
              <EditFilled
                style={{ color: "#3e588c", fontSize: "20px" }}
                onClick={(id) => showModal2(row.id)}
              />
            ),
            xoa: (
              <Popconfirm
                id="TTVConfirm"
                title="Sure to delete?"
                onConfirm={() => onDeleteKhachHang(row.id)}
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
    );
  };

  const onDeleteKhachHang = (id) => {
    axios
      .delete(`https://localhost:7145/api/MemberCard/DeleteMembersCard/${id}`)
      .then(() => {
        getData();
      });
  };

  const addNewMember = () => {
    const data = {
      cardNumber: cardNumber,
      reason: reason,
      issueDate: issueDate,
      validDate: validDate,
      effectDate: effectDate,
    };

    Axios.post(`https://localhost:7145/api/MemberCard/AddMemberCard`, data)
      .then((res) => {
        if (res.data.success) {
          message.success(res.data.message);
          closeModal();
          getData();
        } else {
          message.warning(res.data.message);
        }
      })
      .catch((error) => {
        message.warning(error.response.data.errors.CardNumber);
      });
  };

  const showModal = () => {
    setVisible(true);
  };

  const showModal2 = (id) => {
    setVisible2(true);
    axios
      .get(`https://localhost:7145/api/MemberCard/GetMemberCardById/${id}`)
      .then((res) => {
        setIdEdit(id);
        setCardNumberEdit(res.data.data.cardNumber);
        setReasonEdit(res.data.data.reason);
        setIssueDateEdit(moment(res.data.data.issueDate));
        setEffectDateEdit(moment(res.data.data.effectDateEdit));
        setValidDateEdit(moment(res.data.data.validDateEdit));
        setCustomerName(res.data.data.customer.customerName);
        setRegisterAt(res.data.data.registerAt);
        setImporter(res.data.data.importer);
        setDateAdded(moment(res.data.data.dateAdded));
      });
  };

  const updateCardMember = () => {
    axios
      .put(`https://localhost:7145/api/MemberCard/UpdateMemberCard`, {
        id: idEdit,
        reason: reasonEdit,
        issueDate: moment(issueDateEdit),
        effectDate: moment(effectDateEdit),
        validDate: moment(validDateEdit),
      })
      .then((res) => {
        if (res.data.success) {
          message.success(res.data.message);
          closeModal2();
          getData();
        } else {
          message.warning(res.data.message);
        }
      })
      .catch((error) => {
        message.warning(error.response.data.errors.CardNumber);
      });
  };

  const closeModal = () => {
    setVisible(false);
    setCardNumber("");
    setReason("");
    setIssueDate("");
    setEffectDate("");
    setValidDate("");
  };

  const closeModal2 = () => {
    setVisible2(false);
  };

  const handleOk = () => {
    setVisible(false);
  };

  const handleCancel = () => {
    setVisible(false);
  };

  const handleOk2 = () => {
    setVisible2(false);
  };

  const handleCancel2 = () => {
    setVisible2(false);
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

  const inActiveMemberCard = (id) => {
    axios
      .put(`https://localhost:7145/api/MemberCard/ChangedStatusCard/${id}`)
      .then((res) => {
        if (res.data.success) {
          message.success(res.data.message);
          getData();
        } else {
          message.error(res.data.message);
        }
      });
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
      title: "Số thẻ",
      dataIndex: "sothe",
      key: "sothe",
      width: "10%",
      sorter: (a, b) => a.sothe - b.sothe,
    },
    {
      title: "Loại thẻ",
      dataIndex: "loaithe",
      key: "loaithe",
      width: "10%",
    },
    {
      title: "Ngày ban hành",
      dataIndex: "ngaybanhanh",
      key: "ngaybanhanh",
      width: "10%",
      sorter: (a, b) => a.ngaybanhanh - b.ngaybanhanh,
    },
    {
      title: "Lý do phát hành",
      dataIndex: "lydophathanh",
      key: "lydophathanh",
      width: "10%",
      sorter: (a, b) => a.lydophathanh.localeCompare(b.lydophathanh),
    },
    {
      title: "Hiệu lực từ",
      dataIndex: "hieuluctu",
      key: "hieuluctu",
      width: "10%",
      sorter: (a, b) => a.hieuluctu - b.hieuluctu,
    },
    {
      title: "Hiệu lực đến",
      dataIndex: "hieulucden",
      key: "hieulucden",
      width: "10%",
      sorter: (a, b) => a.hieulucden - b.hieulucden,
    },
    {
      title: "Active",
      dataIndex: "active",
      key: "active",
      width: "5%",
    },
    {
      title: "Khách hàng",
      dataIndex: "khachhang",
      key: "khachhang",
      width: "10%",
      sorter: (a, b) => a.khachhang.localeCompare(b.khachhang),
    },
    {
      title: "Đăng ký tại",
      dataIndex: "dangkytai",
      key: "dangkytai",
      width: "10%",
      sorter: (a, b) => a.dangkytai - b.dangkytai,
    },
    {
      title: "Người nhập",
      dataIndex: "nguoinhap",
      key: "nguoinhap",
      width: "5%",
      sorter: (a, b) => a.nguoinhap.localeCompare(b.nguoinhap),
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

  return (
    <>
      <Row id="CSTDRowContainer">
        <Col span={21} id="TTVColContainer">
          <div id="Container">
            <Search
              placeholder="input search text"
              onSearch={onSearch}
              style={{ width: 200 }}
            />
            <Button type="primary" onClick={showModal}>
              Thêm mới
            </Button>
            <Modal
              className="modalTheThanhVien"
              width={"1200px"}
              title="THÊM MỚI THẺ THÀNH VIÊN"
              centered
              visible={visible}
              onOk={handleOk}
              onCancel={handleCancel}
              footer={[
                <Button key="back" onClick={handleCancel}>
                  Hủy
                </Button>,
                <Button type="primary" htmlType="submit" form="form-add">
                  Thêm
                </Button>,
              ]}
            >
              <Form onFinish={addNewMember} id="form-add">
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Số thẻ</span>
                  <Input
                    name="cardNumber"
                    onChange={(e) => setCardNumber(e.target.value)}
                    value={cardNumber}
                    required
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Loại thẻ</span>
                  <Input value={"Thẻ thành viên"} disabled />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Lý do phát hành thẻ</span>
                  <Input
                    name="reason"
                    value={reason}
                    onChange={(e) => setReason(e.target.value)}
                    required={true}
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Ngày ban hành</span>

                  <DatePicker
                    style={{ marginLeft: "162px", backgroundColor: "#0D378C" }}
                    onChange={(date, dateString) =>
                      setIssueDate(moment(dateString))
                    }
                    name="issueDate"
                    value={issueDate}
                    required={true}
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Hiệu lực từ</span>

                  <DatePicker
                    style={{ marginLeft: "204px", backgroundColor: "#0D378C" }}
                    onChange={(date, dateString) =>
                      setEffectDate(moment(dateString))
                    }
                    name="effectDate"
                    value={effectDate}
                    required={true}
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Hiệu lực đến</span>

                  <DatePicker
                    style={{ marginLeft: "188px", backgroundColor: "#0D378C" }}
                    onChange={(date, dateString) =>
                      setValidDate(moment(dateString))
                    }
                    name="validDate"
                    value={validDate}
                    required={true}
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">khách hàng</span>
                  <Input disabled />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Đăng ký tại</span>
                  <Input disabled />
                </div>
                <div id="audit">
                  <div class="inputFormThemTTV">
                    <span class="inputTextTTV">Ngày nhập/sửa</span>
                    <Input disabled />
                  </div>
                  <div class="inputFormThemTTV">
                    <span class="inputTextTTV">Người nhập/sửa</span>
                    <Input disabled />
                  </div>
                </div>
              </Form>
            </Modal>

            <Modal
              className="modalTheThanhVien"
              width={"1200px"}
              title="CHỈNH SỬA THẺ THÀNH VIÊN"
              centered
              visible={visible2}
              onOk={handleOk2}
              onCancel={handleCancel2}
              footer={[
                <Button key="back" onClick={handleCancel2}>
                  Hủy
                </Button>,
                <Button type="primary" htmlType="submit" form="form-update">
                  Lưu
                </Button>,
              ]}
            >
              <Form onFinish={updateCardMember} id="form-update">
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Số thẻ</span>
                  <Input
                    name="cardNumberEdit"
                    onChange={(e) => setCardNumber(e.target.value)}
                    value={cardNumberEdit}
                    required
                    disabled
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Loại thẻ</span>
                  <Input value={"Thẻ thành viên"} disabled />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Lý do phát hành thẻ</span>
                  <Input
                    name="reasonEdit"
                    value={reasonEdit}
                    onChange={(e) => setReasonEdit(e.target.value)}
                    required={true}
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Ngày ban hành</span>

                  <DatePicker
                    style={{ marginLeft: "162px", backgroundColor: "#0D378C" }}
                    onChange={(date, dateString) =>
                      setIssueDateEdit(moment(dateString))
                    }
                    name="issueDateEdit"
                    value={issueDateEdit}
                    required={true}
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Hiệu lực từ</span>

                  <DatePicker
                    style={{ marginLeft: "202px", backgroundColor: "#0D378C" }}
                    onChange={(date, dateString) =>
                      setEffectDateEdit(moment(dateString))
                    }
                    name="effectDateEdit"
                    value={effectDateEdit}
                    required={true}
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Hiệu lực đến</span>

                  <DatePicker
                    style={{ marginLeft: "186px", backgroundColor: "#0D378C" }}
                    onChange={(date, dateString) =>
                      setValidDateEdit(moment(dateString))
                    }
                    name="validDateEdit"
                    value={validDateEdit}
                    required={true}
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">khách hàng</span>
                  <Input
                    disabled
                    name="customerName"
                    value={
                      customerName === null || customerName === ""
                        ? "-"
                        : customerName
                    }
                  />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputTextTTV">Đăng ký tại</span>
                  <Input disabled name="registerAt" value={registerAt} />
                </div>
                <div id="audit">
                  <div class="inputFormThemTTV">
                    <span class="inputTextTTV">Ngày nhập/sửa</span>
                    <Input
                      disabled
                      name="dateAdded"
                      value={
                        dateAdded === null || dateAdded === "" ? "-" : dateAdded
                      }
                    />
                  </div>
                  <div class="inputFormThemTTV">
                    <span class="inputTextTTV">Người nhập/sửa</span>
                    <Input
                      disabled
                      name="importer"
                      value={
                        importer === null || importer === "" ? "-" : importer
                      }
                    />
                  </div>
                </div>
              </Form>
            </Modal>

            <UserOutlined />
          </div>
          <h2 id="titleTheThanhVien">THẺ THÀNH VIÊN</h2>
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

export default TheThanhVien;
