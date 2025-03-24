import Layout from "./components/layout/Layout";
import Home from "./components/home/Home";
import Gadgets from "./components/gadgets/Gadgets";
//import Inspections from "./components/inspections/Inspections";
import TechnicianView from "./components/technician-view/TechnicianView";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AllCommunityModule, ModuleRegistry, provideGlobalGridOptions } from 'ag-grid-community';
import { ToastContainer, Slide } from "react-toastify";

// Register all AG-Grid community features.  As opposed to including them 1 by 1 to reduce AG-Grid package size
ModuleRegistry.registerModules([AllCommunityModule]);

// Mark all AG-Grids as using legacy themes (pre version 33)
provideGlobalGridOptions({ theme: "legacy" });

export default function App() {

    const NotFound = () => <h2>404 - Page Not Found</h2>;

    return (
        <Router>
            <Layout>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/gadgets" element={<Gadgets />} />
                    {/*<Route path="/inspections" element={<Inspections />} />*/}
                    <Route path="/technician-view" element={<TechnicianView />} />
                    <Route path="*" element={<NotFound />} />
                </Routes>

                <ToastContainer
                    position="bottom-right"
                    autoClose={5000}
                    hideProgressBar={false}
                    newestOnTop={false}
                    closeOnClick
                    rtl={false}
                    pauseOnFocusLoss
                    draggable={false}
                    pauseOnHover
                    theme="dark"
                    transition={Slide}
                />
            </Layout>
        </Router>
    );
}

