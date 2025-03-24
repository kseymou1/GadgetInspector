import "./styles/layout.min.css";
import MainNavigation from "./main-navigation/MainNavigation";

export default function Layout(props) {
    const { children } = props;

    return (
        <div>
            <div id="app-top-bar">
                <MainNavigation />
            </div>

            <div className="p-4">
                {children}
            </div>
        </div>
    );
}
