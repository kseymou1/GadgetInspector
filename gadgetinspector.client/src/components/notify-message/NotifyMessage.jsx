import "react-toastify/dist/ReactToastify.min.css";

export default function NotifyMessage(props) {
    const { header, message = "" } = props;

    return (
        <div style={{ userSelect: "none" }}>
            {header &&
                <div className="pb-2">
                    <strong>{header}</strong>
                </div>
            }

            {message}
        </div>
    );
}