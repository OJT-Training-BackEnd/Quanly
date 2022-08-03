import React, { useRef, useState } from "react";
import { Input, Button, Space, Table, Pagination } from "antd";
import { UserOutlined, SearchOutlined } from "@ant-design/icons";
import "./TheThanhVien.scss";
import Highlighter from "react-highlight-words";

const { Search } = Input;
const onSearch = (value) => console.log(value);

const data = [];

function TheThanhVien() {
  const [searchText, setSearchText] = useState("");
  const [searchedColumn, setSearchedColumn] = useState("");
  const searchInput = useRef(null);
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
      <div id="Container">
        <Search
          placeholder="input search text"
          onSearch={onSearch}
          style={{ width: 200 }}
        />
        <Button type="primary">Thêm mới</Button>
        <UserOutlined />
      </div>
      <h2>THẺ THÀNH VIÊN</h2>
      <Table columns={columns} dataSource={data} />;
      <Pagination defaultCurrent={1} total={10} />;
    </>
  );
}

export default TheThanhVien;
