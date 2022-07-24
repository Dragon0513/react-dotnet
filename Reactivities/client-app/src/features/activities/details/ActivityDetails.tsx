import React from 'react';
import { Button, Card, Image } from 'semantic-ui-react';
import { Activity } from '../../../app/model/activity';
import Moment from 'moment';
import { useStore } from '../../../app/stores/store';
import LoadingComponent from '../../../app/layout/LoadingComponent';


export default function ActivityDetails() {
    const {activityStore} = useStore();
    const {selectedActivity: activity, openForm, cancelSelectedActivity} = activityStore;

    if(!activity) return <LoadingComponent/>;

    return (
        <Card fluid>
            <Image src={`/assets/categoryImages/${activity.category}.jpg`} /> 
            <Card.Content>
                <Card.Header>{activity.title}</Card.Header>
                <Card.Meta>
                    <span >{activity.date}</span>
                </Card.Meta>
                <Card.Description>
                    {activity.description}
                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button.Group width='2'>
                    <Button onClick={() => activityStore.openForm(activity.id)} basic color='blue' content='Edit' />
                    <Button onClick={() => activityStore.cancelSelectedActivity } basic color='grey' content='Cancel' />
                </Button.Group>
            </Card.Content>
        </Card>
    )
}