import { NavItem, NavLink } from 'reactstrap';
import { useLocation } from "react-router-dom";

export default function MainNavItem(props) {
    const { text, url } = props;

    const { pathname } = useLocation();
    const isActive = pathname == url;

    return (
        <NavItem className="primary-nav-item" active={isActive}>
            <NavLink href={url}>{text}</NavLink>
        </NavItem>
    );
}

