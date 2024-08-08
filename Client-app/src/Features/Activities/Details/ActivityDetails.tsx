import React, { Fragment } from 'react';
import {Image, Card, Button } from 'semantic-ui-react';
import { Activity } from '../../../App/Models/Activity';

interface Props {
    activity : Activity
    cancelSelectActivity: () => void;
    openForm: (id: string) => void;
}

export default function ActivityDetails({activity, cancelSelectActivity,
                                        openForm} : Props){
    


    return(
            <Card>
                <Image src={`/Assets/categoryImages/${activity.category}.jpg`} />
                <Card.Content>
                    <Card.Header>{activity.title}</Card.Header>
                    <Card.Meta>
                        <span>{activity.date}</span>
                    </Card.Meta>
                    <Card.Description>
                        {activity.description}
                    </Card.Description>
                </Card.Content>
                <Card.Content>
                    <Button.Group widths='2' />                
                        <Button onClick={() => {openForm(activity.id)}} basic color='blue' content='Edit' />
                        <Button onClick={cancelSelectActivity} basic color='grey' content='Cancel' />
                </Card.Content>
            </Card>
    )
}