import { useState, useCallback, useEffect } from "react";
import { Row, Col } from "reactstrap";
import apiRoutes from "../../../support/routes/apiRoutes";
import GridQuickFilter from "../../grid/grid-quick-filter/GridQuickFilter";
import axios from "axios";
import notify from "../../../support/notify/notify";

export default function GridFilters(props) {
    const { onChange, filterValues} = props;

    const [gadgetTypes, setGadgetTypes] = useState([]);

    //Fetch gadgetTypes
    useEffect(() => {
        axios.get(apiRoutes.gadgetType.get())
            .then(resp => {
                setGadgetTypes(resp.data);
            })
            .catch(() => {
                notify.error("Error fetching Gadget Types.");
            });
    }, []);

    const handleGadgetTypeChange = useCallback(e => {
        const newVal = e.target.value || null; //convert empty string into null here for Inspection/GetGridItems method
        const newFilterValues = { ...filterValues, gadgetTypeId: newVal };
        onChange(newFilterValues);
    }, [onChange, filterValues]);

    const handleQuickFilterChange = useCallback(newVal => {
        const newFilterValues = { ...filterValues, quickFilterText: newVal };
        onChange(newFilterValues);
    }, [onChange, filterValues]);

    return (
        <Row className="mb-3">
            {/* align-items-center is to vertically align the Select with the GridQuickFilter */}
            <Col className="d-flex align-items-center">
                <select onChange={handleGadgetTypeChange} >
                    <option value="">All Gadget Types</option>
                    {
                        gadgetTypes.map((gt) => (
                            <option key={gt.id} value={gt.id}>{gt.name}</option>
                        ))
                    }
                </select>
            </Col>

            {/* Component currently includes <Col></Col> */}
            <GridQuickFilter onChange={handleQuickFilterChange} isDebounced={true} debounceMs={150} />
        </Row>
    );
}