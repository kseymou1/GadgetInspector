import { ListGroupItem } from "reactstrap";

export default function SuggestionItem(props) {
    const { data, onSelect } = props;

    return (
        <ListGroupItem
            action
            onClick={() => onSelect(data)}
            tabIndex={0}
            className="suggestionItem"
        >
            {data.name}
        </ListGroupItem>
    );
} 