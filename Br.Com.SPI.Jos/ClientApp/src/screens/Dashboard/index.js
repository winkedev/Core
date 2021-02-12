import React, { useState } from 'react'
import './style.css';

import { ReactComponent as HomeSVG } from '../../assets/home.svg';
import { ReactComponent as FileSVG } from '../../assets/file.svg';
import { ReactComponent as UserSVG } from '../../assets/user.svg';
import { ReactComponent as LogoutSVG } from '../../assets/logout.svg';
import { ReactComponent as PlugSVG } from '../../assets/plug.svg';

import { ApiConnection } from '../../services/Jost/Api/Connection/Api';

import Logo from '../../assets/jost-logo1.png';
import SPILogo from '../../assets/spi_logo.png';
import DashboardDefault from '../DashboardDefault';
import ConsultaMedicao from '../ConsultaMedicao';
import CadastroMotivo from '../CadastroMotivo';

const Dashboard = () => {

    const [isActive, setIsActive] = useState(true);
    const [indexActive, setIndexActive] = useState(0);

    const setActiveScreen = (index) => {
        switch (index) {
            case 0:
                return <DashboardDefault />
            case 1:
                return <ConsultaMedicao />
            default:
                console.log(index);
        }
    }

    const testConnection = async () => {
        let resp = await ApiConnection.testConnection();
        console.log(resp);
    }

    return (
        <div className="dashboard-container">
            <div id="dashboard-sidebar">
                <div id="sidebar-wrapper" className={isActive ? "active" : ""} onMouseOver={() => setIsActive(false)} onMouseLeave={() => setIsActive(true)}>
                    <nav id="sidebar" className={isActive ? "active" : ""}>
                        <div className="sidebar-logo">
                            <img src={Logo} style={{ borderRadius: "5px" }} />
                            <span>JOSH</span>
                        </div>
                        <div className="sidebar-header">
                            <div className="sidebar-header-box1">
                                <i><UserSVG width={31} height={31} fill="#FFFFFF" opacity="0.5" /></i>
                                <span>Username</span>
                                <a href="#homeSubmenu"
                                    data-toggle="collapse"
                                    aria-expanded="false" style={{ paddingLeft: "15px", display: "flex", justifyContent: "center", alignItems: "center" }} className="dropdown-toggle">

                                </a>
                            </div>
                            <div className="collapse sidebar-header-box2" id="homeSubmenu">
                                <ul className="list-unstyled">
                                    <li>
                                        <a href="javascript:void(0);" onClick={() => testConnection()}>
                                            <i>
                                                <i><LogoutSVG width={31} height={31} fill="#FFFFFF" opacity="0.5" /></i>
                                            </i>
                                            <span>Logout</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <div className="sidebar-body">
                            <ul className="list-unstyled components">
                                {/* <li className="active">
                                <a
                                    href="#homeSubmenu"
                                    data-toggle="collapse"
                                    aria-expanded="false"
                                    className="dropdown-toggle"
                                >
                                    <i>
                                        <FontAwesomeIcon icon={faHome} />
                                    </i>
                                    <span>Page1</span>
                                </a>
                                <ul className="collapse list-unstyled" id="homeSubmenu">
                                    <li>
                                        <a href="#">
                                            <i>
                                                <FontAwesomeIcon icon={faUser} />
                                            </i>
                                            <span>Page1.1</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <i>
                                                <FontAwesomeIcon icon={faUser} />
                                            </i>
                                            <span>Page1.2</span>
                                        </a>
                                    </li>
                                </ul>
                            </li> */}
                                <li>
                                    <a href="javascript:void(0)" onClick={() => setIndexActive(0)}>
                                        <i className="color-alpha">
                                            <HomeSVG width={31} height={31} opacity="0.5" fill="#FFFFFF" />
                                        </i>
                                        <span>Home</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)" onClick={() => setIndexActive(1)}>
                                        <i>
                                            <FileSVG width={31} height={31} opacity="0.5" fill="#FFFFFF" />
                                        </i>
                                        <span>Consulta Medicao</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)" onClick={() => testConnection()}>
                                        <i>
                                            <PlugSVG width={31} height={31} opacity="0.5" fill="#FFFFFF" />
                                        </i>
                                        <span>Testar Conexão</span>
                                    </a>
                                </li>

                            </ul>
                        </div>
                    </nav>
                </div>
            </div>
            <div id="dashboard-main">
                <nav id={isActive ? "db-navbar-active" : ""} className="navbar d-flex justify-content-end align-items-center">
                    <span className="navbar-brand"><i><img src={SPILogo} width={145} height={50} /></i></span>
                </nav>
                <div className="dashboard-main-content">
                    {
                        setActiveScreen(indexActive)
                    }
                </div>
            </div>
        </div>
    )
}

export default Dashboard;