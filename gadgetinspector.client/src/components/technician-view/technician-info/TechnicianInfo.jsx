import TechnicianTypeahead from "../../forms/typeaheads/technician-typeahead/TechnicianTypeahead";
import { Row, Col } from "reactstrap";  

export default function TechnicianInfo(props) {
    const { selectedTechnician, onTechnicianChange } = props;

    return (
        <Row>
            <Col>
                <label className="me-2">Choose a technician:</label>
                <TechnicianTypeahead className="d-inline-block mb-2" onSelect={onTechnicianChange} style={{ maxWidth: "200px" }} />

                {selectedTechnician
                    ? <label className="ms-3 d-inline-block">Viewing as: {selectedTechnician.name}</label>
                    : <label className="ms-3 d-inline-block">No technician selected.</label>
                }

            </Col>
        </Row>
    );
}
