import React from "react";
import "./ThemMoiKhachHang.scss";
import {
  Button,
  Checkbox,
  Col,
  DatePicker,
  Form,
  Input,
  PageHeader,
  Row,
  Select,
  Table,
} from "antd";

const columns = [
  {
    title: 'Số thẻ',
    dataIndex: 'sothe',
    key: 'sothe'
  },
  {
    title: 'Loại thẻ',
    dataIndex: 'loaithe',
    key: 'loaithe',
  },
  {
    title: 'Hiệu lực từ',
    dataIndex: 'hieuluctu',
    key: 'hieuluctu',
  },
  {
    title: 'Hiệu lực đến',
    dataIndex: 'hieulucden',
    key: 'hieulucden',
  },
  {
    title: 'Đăng ký tại',
    dataIndex: 'dangkytai',
    key: 'dangkytai',
  },
  {
    title: 'Người nhập/sửa',
    dataIndex: 'nguoinhapsua',
    key: 'nguoinhapsua',
  },
];
const columns1 = [
  {
    title: 'Họ và tên',
    dataIndex: 'sothe',
    key: 'sothe'
  },
  {
    title: 'Chức vụ',
    dataIndex: 'loaithe',
    key: 'loaithe',
  },
  {
    title: 'Phòng ban',
    dataIndex: 'hieuluctu',
    key: 'hieuluctu',
  },
  {
    title: 'TEL',
    dataIndex: 'hieulucden',
    key: 'hieulucden',
  },
  {
    title: 'Email',
    dataIndex: 'dangkytai',
    key: 'dangkytai',
  },
];

const ThemMoiKhachHang = () => {
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
                      <Input />
                    </Form.Item>
                  </div>
                  <Form.Item label="Tỉnh" name="province" id="content-2">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Loại khách hàng" name="typeOfClient">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Di động" name="mobile">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Điện thoại" name="phone">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Email" name="email">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Fax" name="fax">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Giới tính" name="gender">
                    <Select style={{ width: "515px", marginLeft: "265px", backgroundColor: '#FFF' }}>
                      <Select.Option value="nam">Nam</Select.Option>
                      <Select.Option value="nu">Nữ</Select.Option>
                      <Select.Option value="other">Khác</Select.Option>
                    </Select>
                  </Form.Item>
                  <Form.Item label="Tình trạng hôn nhân" name="maritalStatus">
                    <Select style={{ width: "515px", marginLeft: "154px" }}>
                      <Select.Option value="nam">Nam</Select.Option>
                      <Select.Option value="nu">Nữ</Select.Option>
                      <Select.Option value="other">Khác</Select.Option>
                    </Select>
                  </Form.Item>
                  <Form.Item label="Ngày/tháng/năm sinh" name="birthdate">
                    <DatePicker />
                    </Form.Item>
                  <Form.Item label="CMND" name="cmnd">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Ngày cấp" name="dateRange">
                    <Input />
                  </Form.Item>
                </div>
                <div id="sub-wrapper-2">
                  <span id="title-header-2">Công ty</span>
                  <div id="sub-title-content-2">
                    <div id="sub-title-mini-content">
                      <Form.Item label="Tên công ty" name="nameOfCompany">
                        <Input />
                      </Form.Item>
                      <Form.Item
                        label="Điện thoại công ty"
                        name="phoneOfCompany"
                      >
                        <Input />
                      </Form.Item>
                      <Form.Item label="Người liên hệ" name="contact">
                        <Input />
                      </Form.Item>
                      <Form.Item label="Chức vụ" name="position">
                        <Input />
                      </Form.Item>
                    </div>
                  </div>
                </div>
                <div id="btn">
                  <Button id="btn-save">Lưu</Button>
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
                    <Input />
                  </Form.Item>
                  <Form.Item label="Quận/Huyện" name="district">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Ngôn ngữ" name="language">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Độ tuổi" name="age">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Ngày ghi nhận" name="dateOfRecord">
                    <Input />
                  </Form.Item>
                  <Form.Item label="Nhân viên" name="staff">
                    <Input />
                  </Form.Item>
                </div>
                <div>
                  <span id="title-header-right-1">Thông tin khác</span>
                </div>
                <div id="sub-wrapper-2">
                  <div id="sub-wrapper-2-content">
                    <Form.Item label="Điểm" name="staff">
                      <Input style={{textAlign: 'center', fontSize: '20px'}} defaultValue={'0'} id="input-text-grade" disabled />
                    </Form.Item>
                    <div id="checkbox-item">
                      <Checkbox checked={true}>Active</Checkbox>
                    </div>
                    <Form.Item label="Người nhập sửa" name="editor">
                      <Input id="input-text-editor" disabled />
                    </Form.Item>
                    <Form.Item label="Ngày nhập sửa" name="editDate">
                      <Input id="input-text-editdate" disabled />
                    </Form.Item>
                    <Form.Item label="Ghi chú" name="note">
                      <Input />
                    </Form.Item>
                  </div>
                </div>
                <div>
                  <span id="title-header-right-2">Thẻ thành viên</span>
                </div>
                <div id="sub-wrapper-3">
                  <div id="sub-wrapper-3-content">
                    <Button disabled>
                      Thêm mới
                    </Button>
                    <Table columns={columns}/>
                  </div>
                </div>
                <div>
                  <span id="title-header-right-3">Người liên hệ</span>
                </div>
                <div id="sub-wrapper-4">
                  <div id="sub-wrapper-4-content">
                    <Button disabled>
                      Thêm mới
                    </Button>
                    <Table columns={columns1}/>
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