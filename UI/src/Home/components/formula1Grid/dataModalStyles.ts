import { withStyles, createStyles, Theme } from '@material-ui/core/styles';

export const DataModalStyles = withStyles((theme: Theme) => createStyles({
    modal: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    modalPaper: {
        backgroundColor: theme.palette.background.paper,
        boxShadow: theme.shadows[10],
        padding: theme.spacing(2, 4, 3),
        width: "336px",
        paddingRight: "10px",
        paddingLeft: "10px",
        outline: "none"
    },
    text: {
        width: "100%",
    },
    title: {
        marginBottom: "10px"
    },
    keyboardDatePicker: {
        marginTop: "0px",
        marginBottom: "0px"
    },
    switchFormGroup: {
        marginTop: "10px",
        marginBottom: "10px"
    },
    switchFormControlLabel: {
        marginLeft: "0px",
        color: "rgb(118, 118, 118)"
    }
}));