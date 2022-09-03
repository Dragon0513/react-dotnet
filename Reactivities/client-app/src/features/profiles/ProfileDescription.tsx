import React, { useState } from 'react';
import { Tab, Grid, Header, Button } from 'semantic-ui-react';
import { observer } from 'mobx-react-lite';
import { Profile } from '../../app/model/profile';
import { useStore } from '../../app/stores/store';
import ProfileEditForm from './ProfileEditForm';

interface Props {
  profile: Profile
}

export default observer(function ProfileDescription({profile}: Props){
  const {profileStore: {isCurrentUser}} = useStore();
  const [editMode, setEditMode] = useState(false);
  return (
    <Tab.Pane>
      <Grid>
        <Grid.Column width={16}>
          <Header
            floated='left'
            icon='user'
            content={`About ${profile!.displayName}`}
          />
          {isCurrentUser && (
            <Button
              floated='right'
              basic
              content={editMode ? 'Cancel' : 'Edit Profile'}
              onClick={() => setEditMode(!editMode)}
            />
          )}
        </Grid.Column>
        <Grid.Column width={16}>
          {editMode ? (
            <ProfileEditForm />
          ) : (
            <span>{profile!.bio}</span>
          )}
        </Grid.Column>
      </Grid>
    </Tab.Pane>
  );

});


