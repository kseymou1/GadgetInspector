import { useMemo } from "react";
import { Col } from "reactstrap";
import FloatingLabelTextbox from "../../forms/inputs/floating-label-textbox/FloatingLabelTextbox";
import debounce from 'lodash.debounce';

export default function GridQuickFilter(props) {
    const {
        onChange,
        isDebounced,
        debounceMs = 250 //250 is good for server cals
    } = props;

    //Linter gets mad if I do this:     const debouncedOnChange = useMemo((searchText) => {
    //useMemo appears to magically know to pass through whatever param was passed in to "searchText"
    const debouncedOnChange = useMemo(() => {
        const debounceWaitTime = debounceMs;
        return debounce(searchText => onChange(searchText), debounceWaitTime);
    }, [onChange, debounceMs]);

    function handleChange(e) {
        if (isDebounced) debouncedOnChange(e.target.value);
        else onChange(e.target.value);
    }

    const quickFilterStyles = {
        maxWidth: "250px",
        marginLeft: "auto" //this will push it to the right side even if there are no other filters to the left
    };

    return (
        <Col style={quickFilterStyles}>
            <FloatingLabelTextbox
                label="Quick Search"
                onChange={handleChange}
            />
        </Col>
    );
}