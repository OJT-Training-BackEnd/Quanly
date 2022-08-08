import React, { useEffect, useRef, useState } from "react";
import { Input, Button, Space, Table, Pagination, Col, Row, Checkbox, Spin } from "antd";
import { UserOutlined, SearchOutlined, EditFilled, DeleteFilled } from "@ant-design/icons";
import "./CSTD.scss";
import Highlighter from "react-highlight-words";
import ThemMoiCSTD from "./ThemMoiCSTD";
import MenuProjectManage from "../menu/Menu";
import { Link } from "react-router-dom";
import axios from "axios";

const { Search } = Input;
const onSearch = (value) => console.log(value);

const data = [];

function CSTD() {
  const [searchText, setSearchText] = useState("");
  const [searchedColumn, setSearchedColumn] = useState("");
  const searchInput = useRef(null);
  const [datas, setDatas] = useState([]);
  const [loading, setloading] = useState(true);
  
  const onSearch = (value) => console.log(value);

  useEffect(() => {
    getData();
  }, []);
  const getData = async () => {
    await axios.get("https://localhost:7145/api/AccumulateRule/accumulaterule").then(
      res => {
        setloading(false);
        setDatas(
          res.data.data.map(row => ({
            ma: row.code,
            ten: row.name,
            apdungtu: row.applyFrom === null ? "-" : row.applyFrom,
            apdungden: row.applyTo === null ? "-" : row.applyTo,
            ghichu: row.note === null ? "-" : row.note,
            sua: <EditFilled style={{color: '#3e588c', fontSize: '20px'}} />,
            xoa: <DeleteFilled style={{color: '#0D378C', fontSize: '20px'}}/>
          }))
        );
        console.log(res.data);
      }
    );
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
      title: "Mã",
      dataIndex: "ma",
      key: "ma",
      width: "10%",
      sorter: (a, b) => a.ma - b.ma,
    },
    {
      title: "Tên",
      dataIndex: "ten",
      key: "ten",
      width: "10%",
      sorter: (a, b) => a.ten.localeCompare(b.ten),
    },
    {
      title: "Áp dụng từ",
      dataIndex: "apdungtu",
      key: "apdungtu",
      width: "10%",
      sorter: (a, b) => a.apdungtu - b.apdungtu,
    },
    {
      title: "Áp dụng đến",
      dataIndex: "apdungden",
      key: "apdungden",
      width: "10%",
      sorter: (a, b) => a.apdungden - b.apdungden,
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

  return (
    <>
      <Row id="CSTDRowContainer">
        <Col span={21} id="CSTDColContainer">
          <div id="Container">
            <Search
              placeholder="input search text"
              onSearch={onSearch}
              style={{ width: 200 }}
            />
            <Button type="primary" onClick={ThemMoiCSTD}>
              <Link to="/themmoichinhsachtichdiem" >
              Thêm mới
              </Link>
            </Button>
            <UserOutlined />
          </div>
          <h2 id="titleCSTD">CHÍNH SÁCH TÍCH ĐIỂM</h2>
          {loading ? (
            <Spin size="large" />
          ) : (
          <Table id="table" columns={columns} dataSource={datas} pagination={{position: ["bottomLeft"]}}/>
          )};
        </Col>
      </Row>
    </>
  );
}

export default CSTD;
