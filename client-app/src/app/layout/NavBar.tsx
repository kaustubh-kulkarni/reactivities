import React from "react";
import { Button, Container, Menu, MenuItem } from "semantic-ui-react";

export default function NavBar()
{
    return (
        //Menu component from semantic
        <Menu inverted fixed='top'>
            <Container>
                <MenuItem header>
                    <img src="/assets/logo.png" alt="logo" />
                    Reactivities
                </MenuItem>
                <MenuItem name="Activities" />
                <MenuItem>
                    <Button positive content='Create Activity' />
                </MenuItem>
            </Container>
        </Menu>
    )
}