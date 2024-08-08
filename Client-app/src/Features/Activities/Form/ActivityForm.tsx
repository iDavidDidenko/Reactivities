import React, { Fragment } from "react";
import {Button, Form, Segment } from "semantic-ui-react";
import { Activity } from "../../../App/Models/Activity";

interface Prop {
    activity: Activity | undefined;
    closeForm: () => void;
}

export default function ActivityForm({activity, closeForm} : Prop){
    return(
        <Segment clearing>
            <Form>
                <Form.Input placeholder={activity?.title} />
                <Form.TextArea placeholder='Description' />
                <Form.Input placeholder='Category' />
                <Form.Input placeholder='Date' />
                <Form.Input placeholder='City' />
                <Form.Input placeholder='Venue' />
                <Button floated='right' positive type='submit' content='Submit'/>
                <Button onClick={closeForm} floated='right' type='submit' content='Cancel'/>
            </Form>
        </Segment>
    )
}