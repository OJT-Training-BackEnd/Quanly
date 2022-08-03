import React, { useRef, useState } from "react";
import { Input, Button, Space, Table, Pagination  } from "antd";
import { UserOutlined, SearchOutlined } from "@ant-design/icons";
import "./KhachHang.scss";
import Highlighter from "react-highlight-words";

const { Search } = Input;
const onSearch = (value) => console.log(value);

const data = [
];

function KhachHang() {
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
        title: "Mã",
        dataIndex: "ma",
        key: "ma",
        width: "10%",
        sorter: (a, b) => a.ngay - b.ngay,
      },
      {
        title: "Tên",
        dataIndex: "ten",
        key: "ten",
        width: "10%",
        ...getColumnSearchProps("Tên"),
      },
      {
        title: "Điện thoại",
        dataIndex: "dt",
        key: "dt",
        width: "10%",
        ...getColumnSearchProps("Điện thoại"),
      },
      {
        title: "Tỉnh",
        dataIndex: "tinh",
        key: "tinh",
        width: "5%",
        sorter: (a, b) => a.ngay - b.ngay,
      },
      {
        title: "Loại khách hàng",
        dataIndex: "lkh",
        key: "lkh",
        width: "10%",
        sorter: (a, b) => a.ngay - b.ngay,
      },
      {
        title: "Thẻ",
        dataIndex: "the",
        key: "the",
        width: "10%",
        ...getColumnSearchProps("Thẻ"),
      },
      {
        title: "Người nhập",
        dataIndex: "nguoinhap",
        key: "nguoinhap",
        width: "10%",
        ...getColumnSearchProps("người nhập"),
      },
      {
        title: "Nhân viên",
        dataIndex: "nhanvien",
        key: "nhanvien",
        width: "10%",
        ...getColumnSearchProps("Nhân viên"),
      },
      {
        title: "Ngày t/...",
        dataIndex: "ngayt",
        key: "ngayt",
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
      title: "Action",
      dataIndex: "suaxoa",
      key: "suaxoa",
      width: "20%",
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
        <Button type="primary">Import khách hàng</Button>
        <UserOutlined />
      </div>
      <h2>kHÁCH HÀNG</h2>
      <Table columns={columns} dataSource={data} />;
      <Pagination defaultCurrent={1} total={10} />;
    </>
  );
}

export default KhachHang;
