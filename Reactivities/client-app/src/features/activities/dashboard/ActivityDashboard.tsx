import React from 'react';
import { Grid } from 'semantic-ui-react';
import { Activity } from '../../../app/model/activity';
import ActivityDetails from '../details/ActivityDetails';
import ActivityForm from '../form/ActivityForm';
import ActivityList from './ActivityList';

interface Props {
    activities: Activity[];
    selectedActivity: Activity | undefined;
    selectActivity: (id: string) => void;
    cancelSelectActivity: () => void;
    editMode: boolean;
    openForm: (id: string) => void;
    closeForm: () => void;
    createOrEdit: (activity: Activity) => void;
    deleteActivity: (id: string) => void;
    submitting: boolean
}


export default function ActivityDashboard({activities, selectedActivity, selectActivity, cancelSelectActivity, editMode, openForm, 
    closeForm, createOrEdit, deleteActivity, submitting}:Props) {
    return (
        <Grid>
            <Grid.Column width='10'>
             <ActivityList activities={activities} 
             deleteActivity={deleteActivity}
             selectActivity={selectActivity}
             submitting={submitting}
             ></ActivityList>
            </Grid.Column>
            <Grid.Column width='6'>
                {selectedActivity && !editMode && <ActivityDetails 
                activity={selectedActivity} 
                cancelSelectActivity={cancelSelectActivity}
                openForm={openForm}
                 /> }
                 {editMode &&
                    <ActivityForm 
                    closeForm={closeForm} 
                    activity={selectedActivity} 
                    createOrEdit={createOrEdit}
                    submitting={submitting}></ActivityForm>
                 }                
            </Grid.Column>
        </Grid>
    )
}