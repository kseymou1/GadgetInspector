import { useCallback, useState } from "react";
import PageTitleBar from "../layout/page-title-bar/PageTitleBar";
import TechnicianInfo from "./technician-info/TechnicianInfo";
import InspectionCards from "./inspection-cards/InspectionCards";

export default function TechnicianView() {
    const [selectedTechnician, setSelectedTechnician] = useState();

    const handleTechnicianChange = useCallback(selectedItem => {
        setSelectedTechnician(selectedItem);
    }, []);

    return (
        <>
            <PageTitleBar pageTitle="Technician View" /> {/* should be in Layout, but we are saving time here */}

            <TechnicianInfo onTechnicianChange={handleTechnicianChange} selectedTechnician={selectedTechnician} />

            <InspectionCards selectedTechnicianId={selectedTechnician?.id} />
        </>
    );
}
