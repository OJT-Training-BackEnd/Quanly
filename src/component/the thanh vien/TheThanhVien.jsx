import React, { useRef, useState } from "react";
import {
  Input,
  Button,
  Space,
  Table,
  Pagination,
  DatePicker,
  Modal,
  Row,
  Col,
} from "antd";
import { UserOutlined, SearchOutlined } from "@ant-design/icons";
import "./TheThanhVien.scss";
import MenuProjectManage from "../menu/Menu";
import Highlighter from "react-highlight-words";

function TheThanhVien() {
  const [searchText, setSearchText] = useState("");
  const [searchedColumn, setSearchedColumn] = useState("");
  const searchInput = useRef(null);
  const { Search } = Input;
  const onSearch = (value) => console.log(value);
  const data = [];
  const [visible, setVisible] = useState(false);

  const showModal = () => {
    setVisible(true);
  };

  const handleOk = () => {
    setVisible(false);
  };

  const handleCancel = () => {
    setVisible(false);
  };
  const onChange = (date, dateString) => {
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
      title: "Số thẻ",
      dataIndex: "sothe",
      key: "sothe",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Loại thẻ",
      dataIndex: "loaithe",
      key: "loaithe",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Ngày ban hành",
      dataIndex: "ngaybanhanh",
      key: "ngaybanhanh",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Lý do phát hành",
      dataIndex: "lydophathanh",
      key: "lydophathanh",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Hiệu lực từ",
      dataIndex: "hieuluctu",
      key: "hieuluctu",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Hiệu lực đến",
      dataIndex: "hieulucden",
      key: "hieulucden",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
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
      ...getColumnSearchProps("Ghi chú"),
    },
    {
      title: "Đăng ký tại",
      dataIndex: "dangkytai",
      key: "dangkytai",
      width: "10%",
      sorter: (a, b) => a.ngay - b.ngay,
    },
    {
      title: "Người nhập",
      dataIndex: "nguoinhap",
      key: "nguoinhap",
      width: "10%",
      ...getColumnSearchProps("Ghi chú"),
    },
    {
      title: "Action",
      dataIndex: "suaxoa",
      key: "suaxoa",
      width: "10%",
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
              title="ĐIỀU CHỈNH ĐIỂM"
              centered
              visible={visible}
              onOk={handleOk}
              onCancel={handleCancel}
              footer={[
                <Button key="back" onClick={handleCancel}>
                  Hủy
                </Button>,
                <Button key="submit" type="primary" onClick={handleOk}>
                  Thêm
                </Button>,
              ]}
            >
              <div class="inputFormThemTTV">
                <span class="inputText">Số thẻ</span>
                <Input />
              </div>
              <div class="inputFormThemTTV">
                <span class="inputText">Loại thẻ</span>
                <Input value={"Thẻ thành viên"} disabled />
              </div>
              <div class="inputFormThemTTV">
                <span class="inputText">Lý do phát hành thẻ</span>
                <Input />
              </div>
              <div class="inputFormThemTTV">
                <span class="inputText">Ngày ban hành</span>
                <DatePicker
                  style={{ marginLeft: "160px", backgroundColor: "#0D378C" }}
                  onChange={onChange}
                />
              </div>
              <div class="inputFormThemTTV">
                <span class="inputText">Hiệu lực từ</span>
                <DatePicker
                  style={{ marginLeft: "201px", backgroundColor: "#0D378C" }}
                  onChange={onChange}
                />
              </div>
              <div class="inputFormThemTTV">
                <span class="inputText">Hiệu lực đến</span>
                <DatePicker
                  style={{ marginLeft: "185px", backgroundColor: "#0D378C" }}
                  onChange={onChange}
                />
              </div>
              <div class="inputFormThemTTV">
                <span class="inputText">khách hàng</span>
                <Input disabled />
              </div>
              <div class="inputFormThemTTV">
                <span class="inputText">Đăng ký tại</span>
                <Input disabled />
              </div>
              <div id="audit">
                <div class="inputFormThemTTV">
                  <span class="inputText">Ngày nhập/sửa</span>
                  <Input disabled />
                </div>
                <div class="inputFormThemTTV">
                  <span class="inputText">Người nhập/sửa</span>
                  <Input disabled />
                </div>
              </div>
            </Modal>
            <UserOutlined />
          </div>
          <h2 id="titleTheThanhVien">THẺ THÀNH VIÊN</h2>
          <Table columns={columns} dataSource={data} />;
          <Pagination defaultCurrent={1} total={10} />;
        </Col>
      </Row>
    </>
  );
}

export default TheThanhVien;
