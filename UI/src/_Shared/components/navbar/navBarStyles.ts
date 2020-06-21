import { withStyles, createStyles } from '@material-ui/core/styles';

export const NavBarStyles = withStyles(_ => createStyles({
    grow: {
        flexGrow: 1,
      },
      title: {
          display: 'block',
      },
      sectionDesktop: {
        display: 'flex',
      } ,
      paper: {
        padding: "0px 10px",
      },
      button: {
        textTransform: "none",
        width: "100%"
      },
      identity: {
        margin: "auto",
        cursor: "pointer"
      }
}));