import { PageHeader, Col, Row, Input, DatePicker, Button } from "antd";
import TextArea from "antd/lib/input/TextArea";
import React from "react";
import { Link } from "react-router-dom";
import './ThemMoiCSTD.scss';

function ThemMoiCSTD() {
  const onChange = (date, dateString) => {
    console.log(date, dateString);
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
        <Row>
          <Col span={12}>
            <div className="newCSTD">
              <span>Mã</span>
              <Input />
            </div>
            <div className="newCSTD">
              <span>Tên</span>
              <Input />
            </div>
            <div>
              <span class="dateApdung">Áp dụng từ</span>
              <DatePicker
                style={{ marginLeft: "48px", backgroundColor: "#FFF", marginBottom: '16px', borderRadius: '4px', color: '#0D378C', border: '1px solid #0D378C'}}
                onChange={onChange}
              />
            </div>
            <div>
              <span class="dateApdung">Áp dụng đến</span>
              <DatePicker
                style={{ marginLeft: "35px", backgroundColor: "#FFF", marginBottom: '16px', borderRadius: '4px', color: '#0D378C', border: '1px solid #0D378C'}}
                onChange={onChange}
              />
            </div>
            <div className="newCSTD">
              <span>Hướng dẫn</span>
              <TextArea
              style={{backgroundColor: '#3e588c', color: '#cdcdcd'}}
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
              <TextArea rows={6} style={{marginBottom: '28px'}} />
            </div>
            <div className="newCSTD">
              <span>Ghi chú</span>
              <TextArea rows={10} style={{marginBottom: '28px'}}/>
            </div>
            <div className="newCSTD">
              <span>Ngày nhập/sửa</span>
              <Input disabled style={{backgroundColor: '#3e588c'}}/>
            </div>
            <div className="newCSTD">
              <span>Người nhập/sửa</span>
              <Input disabled style={{backgroundColor: '#3e588c'}}/>
            </div>
            <Button>Lưu</Button>
          </Col>
        </Row>
        
      </div>
    </>
  );
}

export default ThemMoiCSTD;
