import { useState } from 'react';
import { Collapse, Navbar, NavbarToggler, NavbarBrand, Nav } from 'reactstrap';
import MainNavItem from "./main-nav-item/MainNavItem";
import "./styles/main-navigation.min.css";
import { faWrench } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default function MainNavigation() {
    const [isOpen, setIsOpen] = useState(false);
    const toggle = () => setIsOpen(!isOpen);

    return (
        <div className="primary-navigation">
            <Navbar expand="lg">

                <NavbarBrand href="/">
                    <h1>
                        <FontAwesomeIcon icon={faWrench} className="me-3" />
                        Gadget Inspector
                    </h1>
                </NavbarBrand>

                <NavbarToggler onClick={toggle} />
                <Collapse isOpen={isOpen} navbar>
                    <Nav className="me-auto" navbar>
                        {/*<MainNavItem text="Home" url="/" isActive={false} />*/}
                        <MainNavItem text="Gadgets" url="/gadgets" />
                        {/*<MainNavItem text="Inspections" url="/inspections" />*/}
                        <MainNavItem text="Technician View" url="/technician-view" />
                    </Nav>
                </Collapse>
            </Navbar>
        </div>
    );
}
