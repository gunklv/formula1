import React from "react";
import { Formula1Team } from "../../model";
import { Identity } from "../../../_Shared/model";
import { Tooltip, Button } from "@material-ui/core";
import EditIcon from '@material-ui/icons/Edit';
import DeleteIcon from '@material-ui/icons/Delete';
import CheckCircleOutlineIcon from '@material-ui/icons/CheckCircleOutline';
import HighlightOffIcon from '@material-ui/icons/HighlightOff';
import { Formula1TeamGridStyles } from "./formula1TeamGridStyles";

type Formula1TeamGridProps = {
    classes?: any;
    identity: Identity;
    formula1teams: Formula1Team[];
    addButtonClick(): void;
    editButtonClick(formula1Team: Formula1Team): void;
    deleteButtonClick(formula1Team: Formula1Team): void;
}

function Formula1TeamGrid(props: Formula1TeamGridProps){
    return(
        <table className={props.classes.table}>
            <thead>
                <tr>
                    <th>
                        <div className={props.classes.headBlock}>
                            <span>Team Name</span>
                        </div>
                    </th>
                    <th>
                        <div className={props.classes.headBlock}>
                            <span>Foundation Date</span>
                        </div>
                    </th>
                    <th>
                        <div className={props.classes.headBlock}>
                            <span>Victories</span>
                        </div>
                    </th>
                    <th>
                        <div className={props.classes.headBlock}>
                            <span>Fee Paid</span>
                        </div>
                    </th>

                    {props.identity && 
                    <th>
                        <div className={props.classes.block}>
                            <Button className={props.classes.button} onClick={() => props.addButtonClick()} variant="contained" color="primary">
                                Add Team
                            </Button>
                        </div>
                    </th>}
            
                </tr>
            </thead>
            <tbody>
            {props.formula1teams.map(formula1team => {
            return(
                <tr key={formula1team.id}>
                    <td>
                        <div className={props.classes.block}>
                            <span>{formula1team.name}</span>
                        </div>
                    </td>
                    <td>
                        <div className={props.classes.block}>
                            <span>{new Date(formula1team.foundationDate).getFullYear()}</span>
                        </div>
                    </td>
                    <td>
                        <div className={props.classes.block}>
                            <span>{formula1team.victories}</span>
                        </div>
                    </td>
                    <td>
                        <div className={props.classes.block}>
                            {formula1team.isFeePaid ? <CheckCircleOutlineIcon /> : <HighlightOffIcon />}
                        </div>
                    </td>

                    {props.identity && 
                    <td>
                        <div className={props.classes.block}>
                            <Tooltip title="Edit"><EditIcon className={props.classes.icon} onClick={() => props.editButtonClick(formula1team)}/></Tooltip>
                            <Tooltip title="Delete"><DeleteIcon className={props.classes.icon} onClick={() => props.deleteButtonClick(formula1team)} /></Tooltip>
                        </div>
                    </td>}
                        
                </tr>)
            })}
            </tbody>  
        </table>
    )
}

export default Formula1TeamGridStyles(Formula1TeamGrid);