import React from "react";
import { Box, Container, Modal, Fade, Backdrop, Button } from '@material-ui/core';
import { DeleteModalStyles } from "./deleteModalStyles";
import { Formula1Team } from "../../model";

interface DeleteModalProps {
    formula1Team: Formula1Team;
    classes?: any;
    title: string;
    open: boolean;
    handleClose(): void;
    handleConfirm(): void;
}

function DataModal(props: DeleteModalProps) {
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
                        <Box flexGrow={1} p={1} paddingBottom={"15px"}>
                            <h3>{props.title}</h3>
                        </Box>
                        <Box flexGrow={1} p={1} textAlign={"justify"}>
                                Do you really want to delete the <span style={{fontWeight: "bold"}}>{props.formula1Team != null ? props.formula1Team.name : ""}</span> team?
                        </Box>
                        <Box p={1} justifyContent={"space-between"} display={"flex"}>
                            <Button variant="contained" color="default" onClick={props.handleClose} className={props.classes.button}>Cancel</Button>
                            <Button 
                                variant="contained"
                                color="primary"
                                onClick={() => {props.handleConfirm(); props.handleClose()}}
                                className={props.classes.button}
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

export default DeleteModalStyles(DataModal);