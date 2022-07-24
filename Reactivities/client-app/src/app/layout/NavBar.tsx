import React from 'react';
import { Button, Container, Menu } from 'semantic-ui-react';
import { useStore } from '../stores/store';

export default function NavBar() {
    const {activityStore}  = useStore();
    return (
        <Menu inverted  fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src='/assets/logo.png' alt='logo'></img>
                    Reactivities
                </Menu.Item>
                <Menu.Item name='Activities'></Menu.Item>
                <Menu.Item>
                    <Button onClick={() => activityStore.openForm()} positive content='Create Activity'></Button>
                </Menu.Item>
            </Container>
        </Menu>
    )
}