import { withStyles, createStyles, Theme } from '@material-ui/core/styles';

export const Formula1TeamGridStyles = withStyles((theme: Theme) => createStyles({
    table: {
        borderCollapse: "collapse",
        margin: "auto",
        marginTop: "80px",
        "& tr": {
            borderBottom: "1px solid #e2e2e2",
            "& th": {
                borderRight: "1px solid #e2e2e2"
            },
            "& th:nth-child(0)": {
                borderRight: "unset"
            },
            "& td": {
                borderRight: "1px solid #e2e2e2"
            },
            "& td:nth-child(0)": {
                borderRight: "unset"
            },
            "& th:last-child, td:last-child": {
                borderRight: "none"
            }
        }
    },
    block: {
        textAlign: "center",
        width: "160px",
        margin: "10px 20px",
        display: "flex",
        justifyContent: "space-evenly"
    },
    headBlock:{
        textAlign: "center",
        width: "160px",
        margin: "10px 20px",
        background: "#f3f2f2",
        lineHeight: "36px"
    },
    button: {
        textTransform: "none"
    },
    icon: {
        cursor: "pointer"
    }
}));