import React, { useEffect, useRef, useState } from "react";
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
  Upload,
  Checkbox,
  Spin
} from "antd";
import {
  UserOutlined,
  SearchOutlined,
  UploadOutlined,
  EditFilled,
  DeleteFilled,
} from "@ant-design/icons";
import "./KhachHang.scss";
import Highlighter from "react-highlight-words";
import MenuProjectManage from "../menu/Menu";
import { Link } from "react-router-dom";
import Axios from "axios";

const { Search } = Input;


function KhachHang() {
  const [visible4, setVisible4] = useState(false);
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
  await Axios.get("https://localhost:7145/api/Customer").then(
    res => {
      setloading(false);
      setDatas(
        res.data.data.map(row => ({
          ma: row.code,
          ten: row.customerName,
          dt: row.phone,
          tinh: row.province === null ? "-" : row.province,
          lkh: row.type,
          the: row.memberCards === null ? "-" : row.memberCards,
          nguoinhap: row.importer,
          nhanvien: row.contactPersons === null ? "-" : row.contactPersons,
          ngayt: row.dateOfRecord,
          active: row.isActive === true ? <Checkbox style={{marginLeft: '18px'}} defaultChecked disabled /> : <Checkbox style={{marginLeft: '18px'}} defaultChecked={false} disabled />,
          sua: <EditFilled style={{color: '#3e588c', fontSize: '20px'}} />,
          xoa: <DeleteFilled style={{color: '#0D378C', fontSize: '20px'}}/>
        }))
      );
      console.log(res.data);
    }
  );
};
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
      sorter: (a, b) => a.ma.localeCompare(b.ma),
    },
    {
      title: "Tên",
      dataIndex: "ten",
      key: "ten",
      width: "10%",
      sorter: (a, b) => a.ten.localeCompare(b.ten),
    },
    {
      title: "Điện thoại",
      dataIndex: "dt",
      key: "dt",
      width: "10%",
      sorter: (a, b) => a.dt - b.dt,
    },
    {
      title: "Tỉnh",
      dataIndex: "tinh",
      key: "tinh",
      width: "5%",
      sorter: (a, b) => a.tinh.localeCompare(b.tinh),
    },
    {
      title: "Loại khách hàng",
      dataIndex: "lkh",
      key: "lkh",
      width: "10%",
      sorter: (a, b) => a.lkh.localeCompare(b.lkh),
    },
    {
      title: "Thẻ",
      dataIndex: "the",
      key: "the",
      width: "10%",
      sorter: (a, b) => a.the - b.the,
    },
    {
      title: "Người nhập",
      dataIndex: "nguoinhap",
      key: "nguoinhap",
      width: "10%",
      sorter: (a, b) => a.nguoinhap.localeCompare(b.nguoinhap),
    },
    {
      title: "Nhân viên",
      dataIndex: "nhanvien",
      key: "nhanvien",
      width: "10%",
      sorter: (a, b) => a.nhanvien.localeCompare(b.nhanvien),
    },
    {
      title: "Ngày t/...",
      dataIndex: "ngayt",
      key: "ngayt",
      width: "10%",
      sorter: (a, b) => a.ngayt - b.ngayt,
    },
    {
      title: "Active",
      dataIndex: "active",
      key: "active",
      width: "5%",
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
          {loading ? (
            <Spin size="large" />
          ) : (
          <Table columns={columns} pagination={{position: ["bottomLeft"]}} dataSource={datas} />)}
        </Col>
      </Row>
    </>
  );
}

export default KhachHang;
