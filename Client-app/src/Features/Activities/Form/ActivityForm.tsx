import React, { ChangeEvent, useState } from "react";
import {Button, Form, Segment } from "semantic-ui-react";
import { Activity } from "../../../App/Models/Activity";

interface Prop {
    activity: Activity | undefined;
    closeForm: () => void;
    CreateOrEdit: (activity : Activity) => void;
}

export default function ActivityForm({activity: selectedActivity, closeForm, CreateOrEdit} : Prop){
    const initialState = selectedActivity ?? {
        id: '',
        title: '',
        category: '',
        description: '',
        date: '',
        city: '',
        venue: ''
    }

    const [activity, setActivity] = useState(initialState);

    function handleSubmitForm(){
        CreateOrEdit(activity);
    }

    function HandleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>){
        const {name, value} = event.target;
        setActivity({...activity, [name]: value})
    }

    return(
        <Segment clearing>
            <Form onSubmit={handleSubmitForm} autoComplete='off'>
                <Form.Input placeholder='title' value={activity.title} name='title' onChange={HandleInputChange} />
                <Form.TextArea placeholder='Description' value={activity.description} name='description' onChange={HandleInputChange}/>
                <Form.Input placeholder='Category' value={activity.category} name='category' onChange={HandleInputChange}/>
                <Form.Input placeholder='Date' value={activity.date} name='date' onChange={HandleInputChange}/>
                <Form.Input placeholder='City' value={activity.city} name='city' onChange={HandleInputChange}/>
                <Form.Input placeholder='Venue' value={activity.venue} name='venue' onChange={HandleInputChange}/>
                <Button floated='right' positive type='submit' content='Submit'/>
                <Button onClick={closeForm} floated='right' type='submit' content='Cancel'/>
            </Form>
        </Segment>
    )
}