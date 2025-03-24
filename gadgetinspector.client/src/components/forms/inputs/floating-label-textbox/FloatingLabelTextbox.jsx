import { Label, FormGroup, Input } from "reactstrap";
import { useId } from "react";

export default function FloatingLabelTextbox(props) {

    const {
        type = "text",
        id,
        label,
        className,
        style,
        ...rest } = props;

    const generatedId = useId();

    const finalId = id ?? generatedId;

    //FormGroup automatically adds className="mb-3" "noMargin" turns that off
    //We can pass in className="mb-3"" if we want from the parent component
    return (
        <FormGroup
            noMargin={true}
            floating
            className={className}
            style={style}
        >
            <Input
                id={finalId}
                placeholder={label}
                type={type}
                {...rest}
            />

            <Label for={finalId}>
                {label}
            </Label>
        </FormGroup>
    )
}