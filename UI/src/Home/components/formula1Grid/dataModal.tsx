import React, { useState, useEffect } from "react";
import { Box, Container, Grid, Modal, Fade, Backdrop, TextField, Button, FormGroup, FormControlLabel, Switch } from '@material-ui/core';
import { MuiPickersUtilsProvider, KeyboardDatePicker } from '@material-ui/pickers';
import { DataModalStyles } from "./dataModalStyles";
import DateFnsUtils from '@date-io/date-fns';
import { Formula1Team } from "../../model";
import Utils from "../../../_Shared/helpers/utils";

interface DataModalProps {
    formula1Team?: Formula1Team;
    classes?: any;
    title: string;
    open: boolean;
    handleClose(): void;
    handleConfirm(formula1Team: Formula1Team): void;
}

function DataModal(props: DataModalProps) {
    const [name, setName] = useState("");
    const [foundationDate, setFoundationDate] = useState(null);
    const [victories, setVictories] = useState(0);
    const [isFeePaid, setIsFeePaid] = useState(false);

    var f1team = props.formula1Team;
    useEffect(() => {
        setName(f1team != null ? f1team.name : "")
      }, [f1team != null ? f1team.name : ""]);

    useEffect(() => {
        setFoundationDate(f1team != null ? f1team.foundationDate : null)
      }, [f1team != null ? f1team.foundationDate : null]);

    useEffect(() => {
        setVictories(f1team != null ? f1team.victories : 0)
      }, [f1team != null ? f1team.victories : 0]);

    useEffect(() => {
        setIsFeePaid(f1team != null ? f1team.isFeePaid : false)
      }, [f1team != null ? f1team.isFeePaid : false]);

    const isValid = () => {
        return name.length != 0 && (foundationDate !== null && !isNaN(new Date(foundationDate).getTime()) && new Date(foundationDate).getFullYear() >= 1800 && new Date(foundationDate).getFullYear() <= new Date().getUTCFullYear()) && victories == NaN;
    }

    return (
        <Modal
            aria-labelledby="transition-modal-title"
            aria-describedby="transition-modal-description"
            className={props.classes.modal}
            open={props.open}
            onClose={props.handleClose}
            closeAfterTransition
            BackdropComponent={Backdrop}
            BackdropProps={{
                timeout: 500,
                classes: {
                    root: props.classes.modalBackdrop
                }
            }}
        >
            <Fade in={props.open}>
                <div className={props.classes.modalPaper}>
                    <Container>
                        <Box flexGrow={1} p={1} paddingBottom={0}>
                            <h3>{props.title}</h3>
                        </Box>
                        <Box flexGrow={1} p={1}>
                            <TextField className={props.classes.text} label="Team Name" value={name} onChange={(e) => setName(e.currentTarget.value)}/>
                        </Box>
                        <Box p={1}>
                            <MuiPickersUtilsProvider  utils={DateFnsUtils}>
                                <Grid container justify="space-around">
                                    <KeyboardDatePicker
                                    className={props.classes.keyboardDatePicker}
                                    views={["year"]}
                                    margin="normal"
                                    label="Foundation Date"
                                    format="yyyy"
                                    value={foundationDate}
                                    onChange={setFoundationDate}
                                    invalidDateMessage={null}
                                    minDate={new Date("1800-01-01")}
                                    maxDateMessage={"Future date can not be set"}
                                    disableFuture

                                    />
                                </Grid>
                            </MuiPickersUtilsProvider>
                        </Box>
                        <Box flexGrow={1} p={1}>
                            <TextField type="number" inputProps={{ min: "0", step: "1" }} className={props.classes.text} label="Victories" value={victories} onChange={(e) => setVictories(Number(e.target.value))}/>
                        </Box>
                        
                        <Box flexGrow={1} p={1}>
                            <FormGroup row className={props.classes.switchFormGroup}>
                                <FormControlLabel
                                    className={props.classes.switchFormControlLabel}
                                    control={
                                    <Switch
                                        checked={isFeePaid}
                                        onChange={(e) => setIsFeePaid(e.target.checked)}
                                        name="checkedB"
                                        color="primary"
                                        />
                                    }
                                    labelPlacement="start"
                                    label="Fee paid?"
                                    />
                            </FormGroup>
                        </Box>

                        <Box p={1} justifyContent={"space-between"} display={"flex"}>
                            <Button variant="contained" color="default" onClick={props.handleClose} className={props.classes.button}>Cancel</Button>
                            <Button
                                disabled={!isValid()}
                                variant="contained"
                                color="primary"
                                onClick={() => {
                                    props.handleConfirm({
                                        id: (f1team != null && f1team.id ) ? f1team.id : Utils.newGuid(),
                                        name,
                                        foundationDate,
                                        victories: Number(victories),
                                        isFeePaid} as Formula1Team);
                                    props.handleClose()
                                    }}
                                >
                                Confirm
                            </Button>
                        </Box>
                    </Container>
                </div>
            </Fade>
        </Modal>
    );
}

export default DataModalStyles(DataModal);