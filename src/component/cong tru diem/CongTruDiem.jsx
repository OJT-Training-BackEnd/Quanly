import React, { useRef, useState } from "react";
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
} from "antd";
import moment from "moment";
import {
  UserOutlined,
  SearchOutlined,
  UploadOutlined,
} from "@ant-design/icons";
import "./CongTruDiem.scss";
import Highlighter from "react-highlight-words";
import { hover } from "@testing-library/user-event/dist/hover";
import MenuProjectManage from "../menu/Menu";
const { Option } = Select;
const { Search } = Input;
const onSearch = (value) => console.log(value);
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

const data = [];

function CongTruDiem() {
  const [searchText, setSearchText] = useState("");
  const [searchedColumn, setSearchedColumn] = useState("");
  const searchInput = useRef(null);
  const [visible, setVisible] = useState(false);
  const [visible2, setVisible2] = useState(false);
  const [visible3, setVisible3] = useState(false);
  const { RangePicker } = DatePicker;

  const showModal = () => {
    setVisible(true);
  };

  const handleOk = () => {
    setVisible(false);
  };

  const handleCancel = () => {
    setVisible(false);
  };

  const showModal2 = () => {
    setVisible2(true);
  };

  const handleOk2 = () => {
    setVisible2(false);
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
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Lý do",
      dataIndex: "lydo",
      key: "lydo",
      width: "10%",
      ...getColumnSearchProps("Lý do"),
    },
    {
      title: "Thẻ thành viên",
      dataIndex: "ttv",
      key: "ttv",
      width: "10%",
      ...getColumnSearchProps("Thẻ thành viên"),
    },
    {
      title: "Chính sách",
      dataIndex: "chinhsach",
      key: "name",
      width: "10%",
      ...getColumnSearchProps("Chính sách"),
    },
    {
      title: "Điểm",
      dataIndex: "diem",
      key: "diem",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Cửa hàng",
      dataIndex: "cuahang",
      key: "cuahang",
      width: "10%",
      ...getColumnSearchProps("Cửa hàng"),
    },
    {
      title: "Người nhập",
      dataIndex: "nguoinhap",
      key: "nguoinhap",
      width: "10%",
      ...getColumnSearchProps("người nhập"),
    },
    {
      title: "Loại",
      dataIndex: "loai",
      key: "loai",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Ghi chú",
      dataIndex: "ghichu",
      key: "ghichu",
      width: "10%",
      ...getColumnSearchProps("Ghi chú"),
    },
    {
      title: "Action",
      dataIndex: "suaxoa",
      key: "suaxoa",
      width: "20%",
    },
  ];

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
                <DatePicker
                  style={{ marginLeft: "255px", backgroundColor: "#0D378C" }}
                  onChange={onChange2}
                />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Lý do cộng trừ</span>
                <Input placeholder="nhập lý do cộng trừ" />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Số thẻ</span>
                <Input
                  style={{ width: "650px", marginRight: "150px" }}
                  placeholder="Nhập số thẻ"
                />
                <Button id="btn-sothe" type="primary">
                  Tìm thẻ
                </Button>
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
                <Input disabled />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Tỉnh</span>
                <Input disabled />
              </div>
              <div id="loai">
                <span>Loại</span>
                <Select
                  defaultValue="cong"
                  style={{ width: 120, marginLeft: "265px" }}
                >
                  <Option value="cong">CỘNG</Option>
                  <Option value="tru">TRỪ</Option>
                </Select>
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Số tiền</span>
                <Input />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Điểm</span>
                <Input disabled />
              </div>
              <div class="inputFormDieuChinh">
                <span class="inputText">Shop</span>
                <Input disabled />
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
                  <Input />
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
          <Table columns={columns} dataSource={data} />;
          <Pagination defaultCurrent={1} total={10} />;
        </Col>
      </Row>
    </>
  );
}

export default CongTruDiem;
