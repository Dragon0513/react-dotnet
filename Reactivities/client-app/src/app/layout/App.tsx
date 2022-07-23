import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Container} from 'semantic-ui-react';
import { Activity } from '../model/activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import {v4 as uuid} from 'uuid';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setselectedActivity] = useState<Activity | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);

  useEffect(() => {
    axios.get<Activity[]>('https://localhost:7246/api/activities').then(response => {
      console.log(response);
      setActivities(response.data);
    })
  }, [])

  function handleSelectedActivity(id: string) {
    setselectedActivity(activities.find(x => x.id == id));
  }

  function handleCancelSelectActivity() {
    setselectedActivity(undefined);
  }

  function handleFormOpen(id?: string) {
    id ? handleSelectedActivity(id) : handleCancelSelectActivity();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleDeleteActivity(id: string) {
    setActivities([...activities.filter(x => x.id !== id)]);
  }

  function handleCreateOrEditActivity(activity: Activity) {
    activity.id
    ? setActivities([...activities.filter(x => x.id !== activity.id), activity])
    : setActivities([...activities, {...activity, id: uuid()}]);
    setEditMode(false);
    setselectedActivity(activity);
  }

  return (
    <>
        <NavBar openForm={handleFormOpen}></NavBar>
        <Container style={{marginTop: '7em'}}>
         <ActivityDashboard activities={activities}
         selectedActivity={selectedActivity}
         selectActivity={handleSelectedActivity}
         cancelSelectActivity={handleCancelSelectActivity}
         editMode={editMode}
         openForm={handleFormOpen}
         closeForm={handleFormClose}
         createOrEdit={handleCreateOrEditActivity}
         deleteActivity={handleDeleteActivity}
         ></ActivityDashboard>
        </Container>
    </>
  );
}

export default App;
