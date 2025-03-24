import { toast } from 'react-toastify';
import NotifyMessage from "../../components/notify-message/NotifyMessage";

//https://fkhadra.github.io/react-toastify/delay-toast-appearance
//Added to avoid "Cannot update a component while rendering a different component".
const defaultOptions = {
    delay: 1
};

function sendToast(header, message, options, method) {
    const finalOptions = { ...defaultOptions, ...options }
    return toast[method](<NotifyMessage header={header} message={message} />
        , finalOptions);
}

const notify = {
    success: (header, message, options) => sendToast(header, message, options, "success"),
    info: (header, message, options) => sendToast(header, message, options, "info"),
    warn: (header, message, options) => sendToast(header, message, options, "warn"),
    error: (header, message, options) => sendToast(header, message, options, "error"),
};

export default notify;