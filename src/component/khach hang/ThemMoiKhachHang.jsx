import React, { useState } from "react";
import "./ThemMoiKhachHang.scss";
import {
  Button,
  Checkbox,
  Col,
  DatePicker,
  Form,
  Input,
  message,
  PageHeader,
  Row,
  Select,
  Table,
} from "antd";
import axios from "axios";

const ThemMoiKhachHang = () => {
  const [customerName, setCustomerName] = useState("");
  const [importer, setImporter] = useState("");
  const [note, setNote] = useState("");
  const [code, setCode] = useState("");
  const [address, setAddress] = useState("");
  const [type, setType] = useState("");
  const [phone, setPhone] = useState("");
  const [telePhone, setTelephone] = useState("");
  const [email, setEmail] = useState("");
  const [gender, setGender] = useState("NaN");
  const [identityCard, setIdentityCard] = useState("");
  const [issueDate, setIssueDate] = useState();
  const [isMarried, setIsMarried] = useState("Độc thân");
  const [birthDate, setBirthDate] = useState();
  const [companyName, setCompanyName] = useState("");
  const [companyPhone, setCompanyPhone] = useState("");
  const [contact, setContact] = useState("");
  const [position, setPosition] = useState("");
  const [province, setProvince] = useState("");
  const [district, setDistrict] = useState("");
  const [language, setLanguage] = useState("");
  const [age, setAge] = useState("");
  const [dateOfRecord, setDateOfRecord] = useState();
  const [points, setPoints] = useState("");
  const [isActive, setIsActive] = useState(true);

  const columns = [
    {
      title: "Số thẻ",
      dataIndex: "sothe",
      key: "sothe",
    },
    {
      title: "Loại thẻ",
      dataIndex: "loaithe",
      key: "loaithe",
    },
    {
      title: "Hiệu lực từ",
      dataIndex: "hieuluctu",
      key: "hieuluctu",
    },
    {
      title: "Hiệu lực đến",
      dataIndex: "hieulucden",
      key: "hieulucden",
    },
    {
      title: "Đăng ký tại",
      dataIndex: "dangkytai",
      key: "dangkytai",
    },
    {
      title: "Người nhập/sửa",
      dataIndex: "nguoinhapsua",
      key: "nguoinhapsua",
    },
  ];
  const columns1 = [
    {
      title: "Họ và tên",
      dataIndex: "sothe",
      key: "sothe",
    },
    {
      title: "Chức vụ",
      dataIndex: "loaithe",
      key: "loaithe",
    },
    {
      title: "Phòng ban",
      dataIndex: "hieuluctu",
      key: "hieuluctu",
    },
    {
      title: "TEL",
      dataIndex: "hieulucden",
      key: "hieulucden",
    },
    {
      title: "Email",
      dataIndex: "dangkytai",
      key: "dangkytai",
    },
  ];

  const addData = async () => {
    const dataTMKH = {
      customerName: customerName,
      importer: importer,
      note: note,
      code: code,
      address: address,
      type: type,
      email: email,
      birthDate: birthDate,
      identityCard: identityCard,
      issueDate: issueDate,
      companyName: companyName,
      companyPhone: companyPhone,
      contact: contact,
      position: position,
      province: province,
      district: district,
      language: language,
      age: age,
      dateOfRecord: dateOfRecord,
      points: points,
      isActive: isActive,
    };
    await axios
      .post(`https://localhost:7145/api/Customer/Add-User`, dataTMKH)
      .then((res) => {
        if (res.data.success) {
          message.success(res.data.message);
          backToPreviousPage();
        } else {
          message.warning(res.data.message);
        }
      })
      .catch((error) => {
        message.warning(error.response.data.errors.Acc);
      });
  };

  const backToPreviousPage = () => {
    window.history.back();
    setCustomerName("");
    setCode("");
    setPhone("");
    setTelephone("");
    setEmail("");
    setPoints("");
    setAge("");
    setLanguage("");
    setDistrict("");
    setProvince("");
    setPosition("");
    setCompanyPhone("");
    setCompanyName("");
  };

  return (
    <>
      <PageHeader
        className="site-page-header"
        onBack={() => window.history.back()}
        title="THÊM MỚI"
        subTitle="Khách hàng"
      />
      <div id="wrapper">
        <Row>
          <Col span={12}>
            <span id="title-header-1">Thông tin chung</span>
            <div id="sub-content-1">
              <Form>
                <div id="sub-title-content-1">
                  <div id="content-1">
                    <Form.Item label="Mã" name="id">
                      <Input />
                    </Form.Item>
                  </div>
                  <div id="content-2">
                    <Form.Item
                      label="Tên"
                      name="name"
                      rules={[
                        {
                          required: true,
                          message: "You must input name!!!",
                        },
                      ]}
                    >
                      <Input
                        value={customerName}
                        onChange={(e) => setCustomerName(e.target.value)}
                      />
                    </Form.Item>
                  </div>
                  <Form.Item label="Tỉnh" name="province" id="content-2">
                    <Input onChange={(e) => setProvince(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Loại khách hàng" name="typeOfClient">
                    <Input onChange={(e) => setType(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Di động" name="mobile">
                    <Input onChange={(e) => setType(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Điện thoại" name="phone">
                    <Input onChange={(e) => setPhone(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Email" name="email">
                    <Input onChange={(e) => setEmail(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Fax" name="fax">
                    <Input disabled />
                  </Form.Item>
                  <Form.Item label="Giới tính" name="gender">
                    <Select
                      disabled
                      style={{
                        width: "515px",
                        marginLeft: "265px",
                        backgroundColor: "#FFF",
                      }}
                    >
                      <Select.Option value="nam">Nam</Select.Option>
                      <Select.Option value="nu">Nữ</Select.Option>
                      <Select.Option value="other">Khác</Select.Option>
                    </Select>
                  </Form.Item>
                  <Form.Item label="Tình trạng hôn nhân" name="maritalStatus">
                    <Select
                      style={{ width: "515px", marginLeft: "154px" }}
                      disabled
                    >
                      <Select.Option value="nam">Nam</Select.Option>
                      <Select.Option value="nu">Nữ</Select.Option>
                      <Select.Option value="other">Khác</Select.Option>
                    </Select>
                  </Form.Item>
                  <Form.Item label="Ngày/tháng/năm sinh" name="birthdate">
                    <Input
                      type="date"
                      onChange={(e) => setBirthDate(e.target.value)}
                    />
                  </Form.Item>
                  <Form.Item label="CMND" name="cmnd">
                    <Input onChange={(e) => setIdentityCard(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Ngày cấp" name="dateRange">
                    <Input
                      type="date"
                      onChange={(e) => setIssueDate(e.target.value)}
                    />
                  </Form.Item>
                </div>
                <div id="sub-wrapper-2">
                  <span id="title-header-2">Công ty</span>
                  <div id="sub-title-content-2">
                    <div id="sub-title-mini-content">
                      <Form.Item label="Tên công ty" name="nameOfCompany">
                        <Input
                          onChange={(e) => setCompanyName(e.target.value)}
                        />
                      </Form.Item>
                      <Form.Item
                        label="Điện thoại công ty"
                        name="phoneOfCompany"
                      >
                        <Input
                          onChange={(e) => setCompanyPhone(e.target.value)}
                        />
                      </Form.Item>
                      <Form.Item label="Người liên hệ" name="contact">
                        <Input onChange={(e) => setContact(e.target.value)} />
                      </Form.Item>
                      <Form.Item label="Chức vụ" name="position">
                        <Input onChange={(e) => setPosition(e.target.value)} />
                      </Form.Item>
                    </div>
                  </div>
                </div>
                <div id="btn">
                  <Button onClick={() => addData()} id="btn-save">
                    Lưu
                  </Button>
                  <Button id="btn-provide" disabled>
                    Cấp thẻ
                  </Button>
                  <Button id="btn-his" disabled>
                    Lịch sử giao dịch
                  </Button>
                </div>
              </Form>
            </div>
          </Col>
          <Col span={12} id="right-content">
            <span id="title-header-right">Marketing</span>
            <div id="wrapper-right">
              <div id="sub-wrapper-1">
                <div id="sub-wrapper-1-content">
                  <Form.Item label="Tỉnh" name="province">
                    <Input onChange={(e) => setProvince(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Quận/Huyện" name="district">
                    <Input onChange={(e) => setDistrict(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Ngôn ngữ" name="language">
                    <Input onChange={(e) => setLanguage(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Độ tuổi" name="age">
                    <Input onChange={(e) => setAge(e.target.value)} />
                  </Form.Item>
                  <Form.Item label="Ngày ghi nhận" name="dateOfRecord">
                    <Input
                      type="date"
                      onChange={(e) => setDateOfRecord(e.target.value)}
                    />
                  </Form.Item>
                  <Form.Item label="Nhân viên" name="staff">
                    <Input value={"NV"} />
                  </Form.Item>
                </div>
                <div>
                  <span id="title-header-right-1">Thông tin khác</span>
                </div>
                <div id="sub-wrapper-2">
                  <div id="sub-wrapper-2-content">
                    <Form.Item label="Điểm" name="staff">
                      <Input
                        style={{ textAlign: "center", fontSize: "20px" }}
                        defaultValue={"0"}
                        id="input-text-grade"
                        disabled
                      />
                    </Form.Item>
                    <div id="checkbox-item">
                      <Checkbox checked={isActive}>Active</Checkbox>
                    </div>
                    <Form.Item label="Người nhập sửa" name="editor">
                      <Input id="input-text-editor" disabled />
                    </Form.Item>
                    <Form.Item label="Ngày nhập sửa" name="editDate">
                      <Input id="input-text-editdate" disabled />
                    </Form.Item>
                    <Form.Item label="Ghi chú" name="note">
                      <Input onChange={(e) => setNote(e.target.value)} />
                    </Form.Item>
                  </div>
                </div>
                <div>
                  <span id="title-header-right-2">Thẻ thành viên</span>
                </div>
                <div id="sub-wrapper-3">
                  <div id="sub-wrapper-3-content">
                    <Button disabled>Thêm mới</Button>
                    <Table columns={columns} />
                  </div>
                </div>
                <div>
                  <span id="title-header-right-3">Người liên hệ</span>
                </div>
                <div id="sub-wrapper-4">
                  <div id="sub-wrapper-4-content">
                    <Button disabled>Thêm mới</Button>
                    <Table columns={columns1} />
                  </div>
                </div>
              </div>
            </div>
          </Col>
        </Row>
      </div>
    </>
  );
};

export default ThemMoiKhachHang;
