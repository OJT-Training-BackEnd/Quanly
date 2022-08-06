import React, { useState } from "react";
import "antd/dist/antd.css";
import "./Menu.scss";
import { SolutionOutlined, RightCircleFilled } from "@ant-design/icons";
import { Layout, Menu } from "antd";
import { Link } from "react-router-dom";

const { Sider } = Layout;

function getItem(label, key, icon, children) {
  return {
    key,
    icon,
    children,
    label,
  };
}

const items = [
  getItem("quản lý", "sub1", null, [
    getItem(<Link to="/">Cộng / Trừ điểm</Link>, "3", <SolutionOutlined />),
    getItem(<Link to="/khachhang">Khách hàng</Link>, "4", <SolutionOutlined />),
    getItem(<Link to="/thethanhvien">Thẻ thành viên</Link>, "5", <SolutionOutlined />),
    getItem(<Link to="/chinhsachtichdiem">Chính sách tích điểm</Link>, "6", <SolutionOutlined />),
  ]),
  getItem("email/sms", "sub2", null, [
  ]),
  getItem("danh mục", "sub3", null, []),
  getItem("báo cáo", "sub4", null, []),
  getItem("phân quyền/cấu hình", "sub5", null, []),
];

const MenuProjectManage = () => {
  const [collapsed, setCollapsed] = useState(false);
  return (
    <div id="menu">
      <Layout
        style={{
          minHeight: "100vh",
        }}
      >
        <Sider
          trigger={null}
          collapsible
          collapsed={collapsed}
          onCollapse={(value) => setCollapsed(value)}
        >
          <div className="logo" />
          <Menu
            defaultSelectedKeys={["1"]}
            mode="inline"
            items={items}
            expandIcon={<RightCircleFilled />}
          />
        </Sider>
      </Layout>
    </div>
  );
};

export default MenuProjectManage;