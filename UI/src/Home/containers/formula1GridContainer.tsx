import React from "react";
import Formula1TeamGrid from "../components/formula1Grid/formula1TeamGrid";
import DataModal from "../components/formula1Grid/dataModal";
import DeleteModal from "../components/formula1Grid/deleteModal";
import Formula1Services from "../services/formula1Services";
import { Formula1Team } from "../model";
import { connect } from "react-redux";
import { ApplicationState } from "../../_Shared/store/rootReducer";
import { Identity } from "../../_Shared/model";

type Formula1GridContainerProps = {
    identity: Identity;
}

type Formula1GridContainerState = {
    formula1teams: Formula1Team[];
    addModalOpen: boolean;
    editModalOpen: boolean;
    deleteModalOpen: boolean;
    selectedTeam: Formula1Team;
}

class Formula1GridContainer extends React.Component<Formula1GridContainerProps, Formula1GridContainerState>{

    constructor(props: any) {
        super(props);
        this.state = { addModalOpen: false, editModalOpen: false, deleteModalOpen: false, formula1teams: null, selectedTeam: null };
      }

    private readonly formula1Services = new Formula1Services();

    async componentDidMount(){
        this.setState({formula1teams: await this.formula1Services.getFormula1Teams()})
    }

    public render(){
        if(this.state.formula1teams !== null){
            return (
            <>
                <Formula1TeamGrid
                    identity={this.props.identity}
                    formula1teams={this.state.formula1teams}
                    addButtonClick={() => this.setState({addModalOpen: true})}
                    editButtonClick={(formula1Team: Formula1Team) => this.setState({editModalOpen: true, selectedTeam: formula1Team})}
                    deleteButtonClick={(formula1Team: Formula1Team) => this.setState({deleteModalOpen: true, selectedTeam: formula1Team})}
                />

                <DataModal
                    title={"Create Formula1 Team"}
                    open={this.state.addModalOpen}
                    handleClose={() => this.setState({addModalOpen: false})}
                    handleConfirm={async (formula1Team: Formula1Team) => await this.createFormula1Team(formula1Team)}
                />

                <DataModal
                    title={"Edit Formula1 Team"}
                    open={this.state.editModalOpen}
                    handleClose={() => this.setState({editModalOpen: false})}
                    handleConfirm={async (formula1Team: Formula1Team) => await this.updateFormula1Team(formula1Team)}
                    formula1Team={this.state.selectedTeam}
                />

                <DeleteModal
                    title={"Delete Formula1 Team"}
                    open={this.state.deleteModalOpen}
                    handleClose={() => this.setState({deleteModalOpen: false})}
                    handleConfirm={async () => await this.deleteFormula1Team(this.state.selectedTeam.id)}
                    formula1Team={this.state.selectedTeam}
                />
            </>
            );
        }
        else{
            return(
                <div>Loading...</div>
            )
        }
    }

    private async createFormula1Team(formula1Team: Formula1Team): Promise<void>{
        await this.formula1Services.createFormula1Team(formula1Team)
            .then(() => {this.setState({formula1teams: [...this.state.formula1teams, formula1Team]})});
    }

    private async updateFormula1Team(formula1Team: Formula1Team): Promise<void>{
        await this.formula1Services.updateFormula1Team(formula1Team)
            .then(() => {
                var index = this.state.formula1teams.indexOf(this.state.formula1teams.find(x => x.id === formula1Team.id));
                this.state.formula1teams.splice(index, 1, formula1Team);
                this.setState({formula1teams: this.state.formula1teams});
            });
    }

    private async deleteFormula1Team(id: string): Promise<void>{
        await this.formula1Services.deleteFormula1Team(id)
            .then(() => {
                var index = this.state.formula1teams.indexOf(this.state.formula1teams.find(x => x.id === id));
                this.state.formula1teams.splice(index, 1);
                this.setState({formula1teams: this.state.formula1teams});
            });
    }
}

function mapStateToProps(state: ApplicationState) {
    return {
        identity: state.identity
    };
}

export default connect(mapStateToProps)(Formula1GridContainer);