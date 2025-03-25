import { Spinner, Alert } from "reactstrap";
import InspectionCard from "./inspection-card/InspectionCard";
import { useCallback, useEffect, useState } from "react";
import axios from "axios";
import apiRoutes from "../../../support/routes/apiRoutes";
import notify from "../../../support/notify/notify";

export default function InspectionCards(props) {
    const { selectedTechnicianId } = props;

    const [inspections, setInspections] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        if (!selectedTechnicianId) return;

        setIsLoading(true);

        axios.get(apiRoutes.inspection.getForTechnician(selectedTechnicianId))
            .then(resp => {
                setInspections(resp.data);
            })
            .catch(() => {
                notify.error("Error fetching inspections for technician.")
            })
            .finally(() => {
                setIsLoading(false);
            });
    }, [selectedTechnicianId]);

    const handleInspectionCompleted = useCallback(inspectionId => {
        const inspectionsWithItemRemoved = inspections.filter(inspection => inspection.inspectionId !== inspectionId);
        setInspections(inspectionsWithItemRemoved);
    }, [inspections]);

    if (!selectedTechnicianId) return (
        <></>
    );

    if (isLoading) return (
        <h4 style={{ textAlign: "center" }} className="mt-5"><Spinner></Spinner> Loading...</h4>
    );

    if (!inspections.length) return (
        <div style={{width: "100%"}} className="d-flex">
            <Alert color="primary" className="mt-5 margin-auto" style={{ width: "fit-content" }}>You have no inspections currently scheduled.</Alert>
        </div>
    );

    return (
        <div className="d-flex flex-wrap">
            {inspections.map(inspection => (
                <InspectionCard key={inspection.inspectionId} inspection={inspection} onInspectionCompleted={handleInspectionCompleted} />
            ))}
        </div>
    );
}
