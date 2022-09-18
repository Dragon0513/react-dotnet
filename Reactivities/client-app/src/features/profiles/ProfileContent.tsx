import { observer } from "mobx-react-lite";
import React from "react";
import { Tab } from "semantic-ui-react";
import { Profile } from "../../app/model/profile";
import ProfilePhotos from "./ProfilePhotos";
import ProfileDescription from './ProfileDescription';
import ProfileFollowings from "./ProfileFollowings";
import { useStore } from "../../app/stores/store";

interface Props {
    profile: Profile
}

export default observer(function ProfileContent({profile}: Props) {
    const {profileStore} = useStore();

    const panes = [
        {menuItem: 'About', render: () => <ProfileDescription profile={profile}/>},
        {menuItem: 'Photos', render: () => <ProfilePhotos profile={profile}/>},
        {menuItem: 'Events', render: () => <Tab.Pane>Events Content</Tab.Pane>},
        {menuItem: 'Followers', render: () => <ProfileFollowings />},
        {menuItem: 'Following', render: () => <ProfileFollowings />}
    ];

    return (
        <Tab 
            menu={{fluid: true, vertical: true}}
            menuPosition='right'
            panes={panes}
            onTabChange={(e, data) => profileStore.setActiveTab(data.activeIndex)}
        />
    )
})