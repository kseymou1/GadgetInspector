import { useState, useMemo, useCallback, useRef } from "react";
import { ListGroup } from "reactstrap";
import debounce from 'lodash.debounce';
import apiRoutes from "../../../../support/routes/apiRoutes";
import notify from "../../../../support/notify/notify";
import axios from "axios";
import SuggestionItem from "./suggestion-item/SuggestionItem";
import LoadingItem from "./loading-item/LoadingItem";

export default function TechnicianTypeahead(props) {
    const { onSelect, className, ...rest } = props;

    const [isLoading, setIsLoading] = useState(false);
    const [suggestions, setSuggestions] = useState([]);
    const inputRef = useRef(null); //kind of lazy to use a ref instead of making the Input stateful.

    const getSuggestions = useCallback((searchText) => {
        if (!searchText) {
            setSuggestions([]);
            return;
        }

        setIsLoading(true);

        axios.get(apiRoutes.technician.getSuggestions(searchText))
            .then(resp => {
                if (resp.data) setSuggestions(resp.data);
                else setSuggestions([]);
            })
            .catch(() => {
                notify.error("Error fetching Technicians.")
            })
            .finally(() => {
                setIsLoading(false);
            });
    }, []);


    //Linter gets mad if I do this:     const debouncedCallback = useMemo((searchText) => {
    //useMemo appears to magically know to pass through whatever param was passed in to "searchText"
    const debouncedGetSuggestions = useMemo(() => {
        const debounceWaitTime = 250;
        return debounce(searchText => getSuggestions(searchText), debounceWaitTime);
    }, [getSuggestions]);

    function handleChange(newVal) {
        debouncedGetSuggestions(newVal);
    }

    const handleSelect = useCallback(async (data) => {
        await Promise.resolve(onSelect(data));
        setSuggestions([]);
        inputRef.current.value = "";
    }, [onSelect]);


    return (
        <div className={className}>
            <input
                autoFocus
                type="search" //"search" doesn't really do anything more than "text"? besides adding "x" on the right
                onChange={(e) => handleChange(e.target.value)}
                autoComplete="off" //prevents autosuggest and autocomplete at same time
                ref={inputRef}
                className="technician-typeahead form-control"
                {...rest}
            />

            <ListGroup className="technician-typeahead-suggestion-list" style={{ position: "absolute", zIndex: "1" } } >

                {isLoading && <LoadingItem />}

                {
                    suggestions.map((s) => (
                        <SuggestionItem
                            key={s.id}
                            onSelect={handleSelect}
                            data={s}
                        />
                    ))
                }
            </ListGroup>
        </div>
    );
}