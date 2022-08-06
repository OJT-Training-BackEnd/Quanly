import React, { useRef, useState } from "react";
import {
  Input,
  Button,
  Space,
  Table,
  Pagination,
  Col,
  Row,
  Modal,
  message,
  Upload
} from "antd";
import {
  UserOutlined,
  SearchOutlined,
  UploadOutlined,
} from "@ant-design/icons";
import "./KhachHang.scss";
import Highlighter from "react-highlight-words";
import MenuProjectManage from "../menu/Menu";
import { Link } from "react-router-dom";

const { Search } = Input;
const onSearch = (value) => console.log(value);
const props = {
  name: 'file',
  multiple: true,
  action: 'https://www.mocky.io/v2/5cc8019d300000980a055e76',

  onChange(info) {
    const { status } = info.file;

    if (status !== 'uploading') {
      console.log(info.file, info.fileList);
    }

    if (status === 'done') {
      message.success(`${info.file.name} file uploaded successfully.`);
    } else if (status === 'error') {
      message.error(`${info.file.name} file upload failed.`);
    }
  },

  onDrop(e) {
    console.log('Dropped files', e.dataTransfer.files);
  },
};

const data = [];

function KhachHang() {
  const [visible4, setVisible4] = useState(false);
  const [searchText, setSearchText] = useState("");
  const [searchedColumn, setSearchedColumn] = useState("");
  const searchInput = useRef(null);
  const handleSearch = (selectedKeys, confirm, dataIndex) => {
    confirm();
    setSearchText(selectedKeys[0]);
    setSearchedColumn(dataIndex);
  };

  const showModal4 = () => {
    setVisible4(true);
  };

  const handleOk4 = () => {
    setVisible4(false);
  };

  const handleCancel4 = () => {
    setVisible4(false);
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
      <Row id="CSTDRowContainer">
        <Col span={21} id="KHColContainer">
          <div id="Container">
            <Search
              placeholder="input search text"
              onSearch={onSearch}
              style={{ width: 200 }}
            />
            <Button type="primary">
              <Link to="/themmoikhachhang">Thêm mới</Link>
            </Button>
            <Button type="primary" onClick={showModal4}>
              Import khách hàng
            </Button>
            <Modal
              className="modalExcel1"
              width={"770px"}
              title="NHẬP EXCEL"
              centered
              visible={visible4}
              onOk={handleOk4}
              onCancel={handleCancel4}
              footer={[
                <Button key="">Download template</Button>,
                <Button key="submit" type="primary" onClick={handleOk4}>
                  Lưu
                </Button>,
              ]}
            >
              <div id="dragExcel1">
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
          <h2 id="titleKhachHang">KHÁCH HÀNG</h2>
          <Table columns={columns} dataSource={data} />;
          <Pagination defaultCurrent={1} total={10} />;
        </Col>
      </Row>
    </>
  );
}

export default KhachHang;
