export default function getDateStringFromJsDate(val, options) {
    if (!val) return "";

    const defaultOptions = {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
    };

    const finalOptions = { ...defaultOptions, ...options };

    //Passing "undefined" as the locale will use client's locale
    return val.toLocaleDateString(undefined, finalOptions);
}