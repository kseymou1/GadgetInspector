import { useState, useCallback } from "react";
import { Card, CardBody, CardTitle, CardText, ListGroup, ListGroupItem, Button, Spinner } from "reactstrap";
import axios from "axios";
import apiRoutes from "../../../../support/routes/apiRoutes";
import notify from "../../../../support/notify/notify";

export default function InspectionCard(props) {
    const { inspection, onInspectionCompleted } = props;
    const {
        inspectionId,
        gadgetName,
        gadgetTypeName,
        scheduledDate,
    } = inspection;


    const [isSaving, setIsSaving] = useState(false);
    const [completedDate, setCompletedDate] = useState("");
    const [notes, setNotes] = useState("");

    const handleMarkCompleteClick = useCallback(() => {
        const hasMissingFields = !completedDate || !notes;
        if (hasMissingFields) {
            notify.warn("Completed Date and Notes fields are both required.");
            return;
        }

        setIsSaving(true);

        const postParams = { inspectionId: inspectionId, completedDate: completedDate, notes: notes};

        axios.post(apiRoutes.inspection.markComplete(), postParams)
            .then(() => {
                notify.success("Inspection saved as complete");
                onInspectionCompleted(inspectionId);
            })
            .catch(() => {
                notify.error("Error saving inspection as complete.")
            })
            .finally(() => {
                setIsSaving(false);
            })
    }, [inspectionId, completedDate, notes, onInspectionCompleted]);

    const getScheduledDateDisplay = function () {
        if (!scheduledDate) return "TBD";

        const dateOpts = {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            timeZone: "UTC"
        };

        return new Date(scheduledDate).toLocaleDateString(undefined, dateOpts);
    }

    return (
        <div className="p-3 d-flex">
            <Card style={{ width: '19rem', boxShadow: "0 4px 10px rgba(0, 0, 0, 0.1)" }}>

                <CardBody>
                    <CardTitle tag="h5">
                        {gadgetTypeName} - {gadgetName}
                    </CardTitle>
                    <CardText>
                        Scheduled Date: {getScheduledDateDisplay(scheduledDate)}
                    </CardText>
                </CardBody>

                <ListGroup flush>
                    <ListGroupItem>
                        <label className="d-inline-block me-3">Completed:</label>
                        <input
                            type="date"
                            value={completedDate}
                            onChange={e => setCompletedDate(e.currentTarget.value)}
                            className="form-control d-inline-block"
                            style={{ width: "fit-content" }}
                        />
                    </ListGroupItem>
                    <ListGroupItem>
                    <label>Notes:</label>
                        <textarea
                            className="form-control"
                            value={notes}
                            onChange={e => setNotes(e.currentTarget.value)}
                        >
                        </textarea>
                    </ListGroupItem>
                    <ListGroupItem>
                        <Button
                            color="primary"
                            className="m-auto d-flex"
                            onClick={handleMarkCompleteClick}
                            disabled={isSaving}
                        >

                            {isSaving && <Spinner size="sm" className="m-auto me-2"></Spinner> }
                            Mark Inspection Complete
                        </Button>
                    </ListGroupItem>
                </ListGroup>
            </Card>
        </div>
    );
}
