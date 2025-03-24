
export default function PageTitleBar(props) {
    const { pageTitle } = props;

    return (
        <div className="page-title-bar">
            <h2>{pageTitle}</h2>
        </div>
    );
}
