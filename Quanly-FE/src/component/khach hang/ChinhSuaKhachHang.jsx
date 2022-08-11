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
import { useLocation, useNavigate } from "react-router-dom";

const ChinhSuaKhachHang = () => {
    const { state } = useLocation();
    const {
        idEdit,
        importerEdit,
        customerNameEdit,
        noteEdit,
        codeEdit,
        addressEdit,
        typeEdit,
        emailEdit,
        birthDateEdit,
        identityCardEdit,
        issueDateEdit,
        companyNameEdit,
        companyPhoneEdit,
        contactEdit,
        positionEdit,
        provinceEdit,
        districtEdit,
        languageEdit,
        ageEdit,
        dateOfRecordEdit,
        pointsEdit,
        isActiveEdit,
    } = state;
    const navigate = useNavigate();
    const [customerName, setCustomerName] = useState(customerNameEdit);
    const [id, setId] = useState(idEdit);
    const [importer, setImporter] = useState(importerEdit);
    const [note, setNote] = useState(noteEdit);
    const [code, setCode] = useState(codeEdit);
    const [address, setAddress] = useState(addressEdit);
    const [type, setType] = useState(typeEdit);
    const [email, setEmail] = useState(emailEdit);
    const [gender, setGender] = useState("NaN");
    const [identityCard, setIdentityCard] = useState(identityCardEdit);
    const [issueDate, setIssueDate] = useState(issueDateEdit);
    const [isMarried, setIsMarried] = useState("Độc thân");
    const [birthDate, setBirthDate] = useState(birthDateEdit);
    const [companyName, setCompanyName] = useState(companyNameEdit);
    const [companyPhone, setCompanyPhone] = useState(companyPhoneEdit);
    const [contact, setContact] = useState(contactEdit);
    const [position, setPosition] = useState(positionEdit);
    const [province, setProvince] = useState(provinceEdit);
    const [district, setDistrict] = useState(districtEdit);
    const [language, setLanguage] = useState(languageEdit);
    const [age, setAge] = useState(ageEdit);
    const [dateOfRecord, setDateOfRecord] = useState(dateOfRecordEdit);
    const [points, setPoints] = useState(pointsEdit);
    const [isActive, setIsActive] = useState(isActiveEdit);

    console.log(state);
    console.log(birthDate)

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

    //   const backToPreviousPage = () => {
    //     window.history.back();
    //     setCustomerName("");
    //     setCode("");
    //     setPhone("");
    //     setTelephone("");
    //     setEmail("");
    //     setPoints("");
    //     setAge("");
    //     setLanguage("");
    //     setDistrict("");
    //     setProvince("");
    //     setPosition("");
    //     setCompanyPhone("");
    //     setCompanyName("");
    //   };

    const updateData = () => {
        const data = {
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
        }
        console.log(data);
        axios.put(`http://localhost:7145/api/Customer/Update-User`, data).then(res => {
            if (res.data.success) {
                message.success(res.data.message);
                navigate('/khachhang');
            } else {
                message.error(res.data.message);
            }
        })
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
                                        <Form.Item label="Mã">
                                            <Input name="code" value={code} />
                                        </Form.Item>
                                    </div>
                                    <div id="content-2">
                                        <Form.Item
                                            label="Tên"
                                            rules={[
                                                {
                                                    required: true,
                                                    message: "You must input name!!!",
                                                },
                                            ]}
                                        >
                                            <Input
                                                name="customerName"
                                                value={customerName}
                                                onChange={(e) => setCustomerName(e.target.value)}
                                            />
                                        </Form.Item>
                                    </div>
                                    <Form.Item label="Tỉnh" id="content-2">
                                        <Input
                                            name="province"
                                            value={province}
                                            onChange={(e) => setProvince(e.target.value)}
                                        />
                                    </Form.Item>
                                    <Form.Item label="Loại khách hàng" >
                                        <Input name="type"
                                            value={type}
                                            onChange={(e) => setType(e.target.value)}
                                        />
                                    </Form.Item>
                                    <Form.Item label="Di động" name="mobile">
                                        <Input disabled />
                                    </Form.Item>
                                    <Form.Item value={code} label="Điện thoại" name="phone">
                                        <Input disabled />
                                    </Form.Item>
                                    <Form.Item label="Email" name="email">
                                        <Input
                                            value={email}
                                            onChange={(e) => setEmail(e.target.value)} disabled
                                        />
                                    </Form.Item>
                                    <Form.Item label="Fax" name="fax">
                                        <Input disabled />
                                    </Form.Item>
                                    <Form.Item label="Giới tính">
                                        <Select
                                            disabled
                                            name='gender'
                                            value={gender}
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
                                    <Form.Item label="Tình trạng hôn nhân">
                                        <Select
                                            value={isMarried}
                                            name='isMarried'
                                            style={{ width: "515px", marginLeft: "154px" }}
                                            disabled
                                        >
                                            <Select.Option value="nam">Nam</Select.Option>
                                            <Select.Option value="nu">Nữ</Select.Option>
                                            <Select.Option value="other">Khác</Select.Option>
                                        </Select>
                                    </Form.Item>
                                    <Form.Item label="Ngày/tháng/năm sinh">
                                        <Input
                                            type="date"
                                            value={birthDate}
                                            name='birthDate'
                                            onChange={(e) => setBirthDate(e.target.value)}
                                        />
                                    </Form.Item>
                                    <Form.Item label="CMND">
                                        <Input
                                            value={identityCard}
                                            name='identityCard'
                                            onChange={(e) => setIdentityCard(e.target.value)}
                                        />
                                    </Form.Item>
                                    <Form.Item label="Ngày cấp">
                                        <Input
                                            value={issueDate}
                                            name='issueDate'
                                            type="date"
                                            onChange={(e) => setIssueDate(e.target.value)}
                                        />
                                    </Form.Item>
                                </div>
                                <div id="sub-wrapper-2">
                                    <span id="title-header-2">Công ty</span>
                                    <div id="sub-title-content-2">
                                        <div id="sub-title-mini-content">
                                            <Form.Item label="Tên công ty">
                                                <Input
                                                    value={companyName}
                                                    name='companyName'
                                                    onChange={(e) => setCompanyName(e.target.value)}
                                                />
                                            </Form.Item>
                                            <Form.Item
                                                label="Điện thoại công ty"
                                            >
                                                <Input
                                                    value={companyPhone}
                                                    name={companyPhone}
                                                    onChange={(e) => setCompanyPhone(e.target.value)}
                                                />
                                            </Form.Item>
                                            <Form.Item label="Người liên hệ">
                                                <Input
                                                    name="contact"
                                                    value={contact}
                                                    onChange={(e) => setContact(e.target.value)}
                                                />
                                            </Form.Item>
                                            <Form.Item label="Chức vụ" >
                                                <Input
                                                    name="position"
                                                    value={position}
                                                    onChange={(e) => setPosition(e.target.value)}
                                                />
                                            </Form.Item>
                                        </div>
                                    </div>
                                </div>
                                <div id="btn">
                                    <Button onClick={() => updateData()} id="btn-save">
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
                                    <Form.Item label="Tỉnh" >
                                        <Input name="province" value={province} onChange={(e) => setProvince(e.target.value)} />
                                    </Form.Item>
                                    <Form.Item label="Quận/Huyện">
                                        <Input name="district" value={district} onChange={(e) => setDistrict(e.target.value)} />
                                    </Form.Item>
                                    <Form.Item label="Ngôn ngữ">
                                        <Input name="language" value={language} onChange={(e) => setLanguage(e.target.value)} />
                                    </Form.Item>
                                    <Form.Item label="Độ tuổi" >
                                        <Input name="age" value={age} onChange={(e) => setAge(e.target.value)} />
                                    </Form.Item>
                                    <Form.Item label="Ngày ghi nhận" name="dateOfRecord">
                                        <Input
                                            type="date"
                                            onChange={(e) => setDateOfRecord(e.target.value)}
                                        />
                                    </Form.Item>
                                    <Form.Item label="Nhân viên" name="staff">
                                        <Input disabled />
                                    </Form.Item>
                                </div>
                                <div>
                                    <span id="title-header-right-1">Thông tin khác</span>
                                </div>
                                <div id="sub-wrapper-2">
                                    <div id="sub-wrapper-2-content">
                                        <Form.Item label="Điểm">
                                            <Input
                                                style={{ textAlign: "center", fontSize: "20px" }}
                                                value={parseInt(points).toString()}
                                                id="input-text-grade"
                                                disabled
                                            />
                                        </Form.Item>
                                        <div id="checkbox-item">
                                            <Checkbox checked={isActive}>Active</Checkbox>
                                        </div>
                                        <Form.Item label="Người nhập sửa">
                                            <Input name='importer' value={importer} id="input-text-editor" disabled />
                                        </Form.Item>
                                        <Form.Item label="Ngày nhập sửa">
                                            <Input name='dateOfRecord' value={dateOfRecord} id="input-text-editdate" disabled />
                                        </Form.Item>
                                        <Form.Item label="Ghi chú">
                                            <Input name='note' value={note} onChange={(e) => setNote(e.target.value)} />
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

export default ChinhSuaKhachHang;
