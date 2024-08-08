import React from 'react';
import { Button, Container, Menu } from 'semantic-ui-react';

interface Prop {
    openForm: () => void;
}

export default function NavBar({openForm} : Prop){
    return(
        // stype in react defined as an object {}
        <Menu inverted fixed='top'> 
            <Container>
                <Menu.Item header> 
                    <img src="/Assets/logo.png" alt="logo" style={{marginRight: 10}}/>
                    Reactivites
                </Menu.Item>
                <Menu.Item name='Activities'/>
                <Menu.Item>
                    <Button onClick={openForm} positive content='Create Activity'/>
                </Menu.Item>
            </Container>
        </Menu>
    )
}
