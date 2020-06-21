import { withStyles, createStyles, Theme } from '@material-ui/core/styles';

export const DeleteModalStyles = withStyles((theme: Theme) => createStyles({
    modal: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    modalBackdrop: {
        zIndex: theme.zIndex.drawer + 1,
    },
    modalPaper: {
        backgroundColor: theme.palette.background.paper,
        boxShadow: theme.shadows[10],
        padding: theme.spacing(2, 4, 3),
        zIndex: theme.zIndex.drawer + 2,
        width: "336px",
        paddingRight: "10px",
        paddingLeft: "10px"
    },
    text: {
        width: "100%",
    },
    title: {
        marginBottom: "10px"
    },
    termsOfConditionsBox: {
        paddingBottom: '10px',
    },
    termsOfConditionsCheckbox: {
        padding: '0px',
        marginRight: '5px'
    }
}));