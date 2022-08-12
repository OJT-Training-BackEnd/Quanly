import {
  PageHeader,
  Col,
  Row,
  Input,
  DatePicker,
  Button,
  message,
  Form,
} from "antd";
import TextArea from "antd/lib/input/TextArea";
import React, { useState } from "react";
import { Link, useLocation } from "react-router-dom";
import "./ThemMoiCSTD.scss";
import axios from "axios";
import moment from "moment";

function ThemMoiCSTD() {
  const [code, setCode] = useState("");
  const [name, setName] = useState("");
  const [applyFrom, setApplyFrom] = useState("");
  const [applyTo, setApplyTo] = useState("");
  const [note, setNote] = useState("");


  const addNewAccumulateRule = () => {
    const data = {
      code: code,
      name: name,
      applyFrom: applyFrom,
      applyTo: applyTo,
      note: note,
    };
    axios
      .post(
        `https://localhost:7145/api/AccumulateRule/AddNewAcumulateRule`,
        data
      )
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
    setCode("");
    setName("");
    setApplyFrom("");
    setApplyTo("");
    setNote("");
  };

  const getAccumulateRuleById = (idRule) => {
    axios
      .get(
        `https://localhost:7145/api/AccumulateRule/GetAccumulateRuleById/${idRule}`
      )
      .then((res) => {
        console.log(res.data.data);
      });
  };

  return (
    <>
      <PageHeader
        className="site-page-header"
        onBack={() => window.history.back()}
        title="THÊM MỚI"
        subTitle="Chính sách tích điểm"
      />

      <div id="formThemMoiCSTD">
        <h2 id="titleNewCSTD">CHÍNH SÁCH TÍCH LŨY ĐIỂM</h2>
        <Form onFinish={addNewAccumulateRule}>
          <Row>
            <Col span={12}>
              <div className="newCSTD">
                <span>Mã</span>
                <Input
                  required={true}
                  name="code"
                  value={code}
                  onChange={(e) => setCode(e.target.value)}
                />
              </div>
              <div className="newCSTD">
                <span>Tên</span>
                <Input
                  required={true}
                  name="name"
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                />
              </div>
              <div>
                <span class="dateApdung">Áp dụng từ</span>
                <DatePicker
                  style={{
                    marginLeft: "48px",
                    backgroundColor: "#FFF",
                    marginBottom: "16px",
                    borderRadius: "4px",
                    color: "#0D378C",
                    border: "1px solid #0D378C",
}}
                  onChange={(date, dateString) =>
                    setApplyFrom(moment(dateString))
                  }
                  name="applyFrom"
                  value={applyFrom}
                />
              </div>
              <div>
                <span class="dateApdung">Áp dụng đến</span>
                <DatePicker
                  style={{
                    marginLeft: "35px",
                    backgroundColor: "#FFF",
                    marginBottom: "16px",
                    borderRadius: "4px",
                    color: "#0D378C",
                    border: "1px solid #0D378C",
                  }}
                  onChange={(date, dateString) =>
                    setApplyTo(moment(dateString))
                  }
                  name="applyTo"
                  value={applyTo}
                />
              </div>
              <div className="newCSTD">
                <span>Hướng dẫn</span>
                <TextArea
                  style={{ backgroundColor: "#3e588c", color: "#cdcdcd" }}
                  rows={14}
                  value="* Sử dụng các Mã sau đây để lập công thức tính:
                  - Loai: khi muốn tham chiếu đến lý do cộng trừ
                  - Amount: khi muốn tham chiếu đến giá trị hóa đơn
                  - TopupQty: khi muốn tham chiếu đến số lần nạp tiền
                  - SinhNhat: bằng 1 nếu là ngày sinh nhật
                  - weekday: 1=sunday, 2=monday,...,7=saturday
                  - hour: giờ trong ngày (định dạng 24h)."
                  disabled
                />
              </div>
            </Col>
            <Col span={12}>
              <div className="newCSTD">
                <span>Công thức</span>
                <TextArea
                  rows={6}
                  style={{
                    marginBottom: "28px",
                    background: "#77a1d9",
                    color: "#fff",
                  }}
                  disabled
                  defaultValue={"Amount"}
                />
              </div>
              <div className="newCSTD">
                <span>Ghi chú</span>
                <TextArea
                  rows={10}
                  style={{ marginBottom: "28px" }}
                  name="note"
                  value={note}
                  onChange={(e) => setNote(e.target.value)}
                />
              </div>
              <div className="newCSTD">
                <span>Ngày nhập/sửa</span>
                <Input disabled style={{ backgroundColor: "#3e588c" }} />
              </div>
              <div className="newCSTD">
                <span>Người nhập/sửa</span>
                <Input disabled style={{ backgroundColor: "#3e588c" }} />
              </div>
              <Button htmlType="submit">Lưu</Button>
            </Col>
          </Row>
        </Form>
      </div>
    </>
  );
}
export default ThemMoiCSTD;