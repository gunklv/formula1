import React, { useState } from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import Typography from '@material-ui/core/Typography';
import Menu from '@material-ui/core/Menu';
import AccountCircle from '@material-ui/icons/AccountCircle';
import { TextField, Button, Box } from '@material-ui/core';
import { Identity } from '../../model';
import { NavBarStyles } from './navBarStyles';

type NavBarProps = {
  classes?: any;
  signIn(userName: string, password: string): void;
  signOut(): void;
  identity: Identity;
}

function NavBar(props: NavBarProps) {
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");

  const [anchorEl, setAnchorEl] = React.useState(null);

  const isMenuOpen = Boolean(anchorEl);

  const isValid = () =>  {
    return userName.length !== 0 && password.length !== 0;
  }

  const handleProfileMenuOpen = (event: any) => {
    setAnchorEl(event.currentTarget);
  };

  const handleMenuClose = () => {
    setAnchorEl(null);
  };

  const renderSigninMenu = (
    <Menu
      transitionDuration={0}
      classes={{paper: props.classes.paper}}
      anchorEl={anchorEl}
      open={isMenuOpen}
      onClose={handleMenuClose}
    >
      <div onKeyDown={(e: any) => {e.key === "Tab" && e.stopPropagation()}}>
          <Box p={1}>
            <TextField label="User Name" value={userName} onChange={e => setUserName(e.target.value)} />
          </Box>
          <Box p={1}>
            <TextField type="password" value={password}  label="Password" onChange={e => setPassword(e.target.value)} />
          </Box>
          <Box p={1} textAlign={"center"}>
            <Button disabled={!isValid()} className={props.classes.button} onClick={async () => {handleMenuClose(); await props.signIn(userName, password);}} variant="contained" color="primary">
              Sign In
            </Button>
          </Box>
      </div>
    </Menu>
  );

  const renderSignoutMenu = (
    <Menu
      transitionDuration={0}
      classes={{paper: props.classes.paper}}
      anchorEl={anchorEl}
      open={isMenuOpen}
      onClose={handleMenuClose}
    >
      <Button className={props.classes.button} onClick={async () => {handleMenuClose(); await props.signOut(); }} variant="contained" color="primary">
        Sign Out
      </Button>
    </Menu>
  );

  return (
    <div className={props.classes.grow}>
      <AppBar>
        <Toolbar>
          <Typography className={props.classes.title} variant="h6" noWrap>
            Formula1 Teams
          </Typography>
          <div className={props.classes.grow} />
          <div className={props.classes.sectionDesktop}>
            {props.identity && <span className={props.classes.identity} onClick={handleProfileMenuOpen}>{props.identity.name}</span>}
            <IconButton
              edge="end"
              aria-label="account of current user"
              aria-haspopup="true"
              onClick={handleProfileMenuOpen}
              color="inherit"
            >
              <AccountCircle />
            </IconButton>
          </div>
        </Toolbar>
      </AppBar>
      {props.identity ? renderSignoutMenu : renderSigninMenu}
    </div>
  );
}

export default NavBarStyles(NavBar);