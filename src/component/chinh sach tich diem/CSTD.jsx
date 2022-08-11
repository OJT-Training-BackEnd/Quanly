import React, { useEffect, useRef, useState } from "react";
import { Input, Button, Space, Table, Pagination, Col, Row, Checkbox, Spin, Popconfirm } from "antd";
import { UserOutlined, SearchOutlined, EditFilled, DeleteFilled } from "@ant-design/icons";
import "./CSTD.scss";
import Highlighter from "react-highlight-words";
import ThemMoiCSTD from "./ThemMoiCSTD";
import MenuProjectManage from "../menu/Menu";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";

const { Search } = Input;

function CSTD() {
  const navigate = useNavigate();
  const [searchText, setSearchText] = useState("");
  const [searchedColumn, setSearchedColumn] = useState("");
  const searchInput = useRef(null);
  const [datas, setDatas] = useState([]);
  const [loading, setloading] = useState(true);


  useEffect(() => {
    getData();
  }, []);

  const getAccumulateRuleById = (id) => {
    axios.get(`https://localhost:7145/api/AccumulateRule/GetAccumulateRuleById/${id}`).then(res => {
      navigate('/chinhsuachinhsachtichdiem', {state: {
        idEdit: id,
        codeEdit: res.data.data.code,
        nameEdit: res.data.data.name,
        applyFromEdit: res.data.data.applyFrom,
        applyToEdit: res.data.data.applyTo,
        noteEdit: res.data.data.note,
        importer: res.data.data.importer,
        dateAdded: res.data.data.dateAdded,
      }})
    })
  }

  const getData = async () => {
    await axios.get("https://localhost:7145/api/AccumulateRule/GetAllAccumulateRule").then(
      res => {
        setloading(false);
        setDatas(
          res.data.data.map(row => ({
            id: row.id,
            ma: row.code === null ? "-" : row.code,
            ten: row.name,
            apdungtu: row.applyFrom === null ? "-" : row.applyFrom,
            apdungden: row.applyTo === null ? "-" : row.applyTo,
            ghichu: row.note === null ? "-" : row.note,
            sua: <EditFilled style={{color: '#3e588c', fontSize: '20px'}} onClick={() => getAccumulateRuleById(row.id)} />,
            xoa: (
              <Popconfirm
                title="Sure to delete?"
                onConfirm={() => onCSTD(row.id)}
              >
                <DeleteFilled
                  key={row.id}
                  style={{ color: "#0D378C", fontSize: "20px" }}
                />
              </Popconfirm>
            ),
          }))
        );
        console.log(res.data);
      }
    );
  };

  const onSearch = (value) => {
    if (value == '') {
      getData();
    } else {
      axios.get( `https://localhost:7145/api/AccumulateRule/SearchAccumulatePointRule/${value}`)
      .then((res) => {
        console.log(res.data.success);
        if (res.data.data === null) {
          setDatas([]);
        } else {
          setloading(false);
          setDatas(
            res.data.data.map(row => ({
              id: row.id,
              ma: row.code === null ? "-" : row.code,
              ten: row.name,
              apdungtu: row.applyFrom === null ? "-" : row.applyFrom,
              apdungden: row.applyTo === null ? "-" : row.applyTo,
              ghichu: row.note === null ? "-" : row.note,
              sua: <EditFilled style={{color: '#3e588c', fontSize: '20px'}} />,
              xoa: (
                <Popconfirm
                  title="Sure to delete?"
                  onConfirm={() => onCSTD(row.id)}
                >
                  <DeleteFilled
                    key={row.id}
                    style={{ color: "#0D378C", fontSize: "20px" }}
                  />
                </Popconfirm>
              ),
            }))
          )
        }
      });
    }
  }

  const onCSTD = (id) => {
    axios
      .delete(`https://localhost:7145/api/AccumulateRule/DeleteAccumulateRule/${id}`)
      .then(() => {
        getData();
      });
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
          )}
        </Col>
      </Row>
    </>
  );
}

export default CSTD;
