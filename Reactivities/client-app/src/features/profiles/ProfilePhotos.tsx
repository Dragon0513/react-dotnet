import { observer } from "mobx-react-lite";
import React, { SyntheticEvent, useState } from "react";
import { Card, Header, Tab, Image, Grid, Button } from "semantic-ui-react";
import PhotoUploadWidget from "../../app/common/imageUpload/PhotoUploadWidget";
import { Photo, Profile } from "../../app/model/profile";
import { useStore } from "../../app/stores/store";

interface Props {
    profile: Profile;
}

export default observer(function ProfilePhotos({profile}: Props) {
    const {profileStore: {isCurrentUser, uploadPhoto, 
        uploading, loading, setMainPhoto, deletePhoto}} = useStore();
    const [addPhotoMode, setAddPhotoMode] = useState(false);
    const [target, setTarget] = useState(''); 

    function handlePhotoUpload(file: Blob) {
        uploadPhoto(file).then(() => setAddPhotoMode(false));
    }

    function handleSetMainPhoto(photo: Photo, e: SyntheticEvent<HTMLButtonElement>) {
        setTarget(e.currentTarget.name);
        setMainPhoto(photo);
    }

    function handleDeletePhoto(photo: Photo, e: SyntheticEvent<HTMLButtonElement>) {
        setTarget(e.currentTarget.name);
        deletePhoto(photo);
    }

    return (
        <Tab.Pane>
            <Grid>
                <Grid.Column width={16}>
                    <Header floated='left' icon='image' content='Photos'/>
                    {isCurrentUser && (
                        <Button floated="left" basic content={addPhotoMode ? 'Cancel' : 'Add Photo'}
                         onClick={() => setAddPhotoMode(!addPhotoMode)} />
                    )}
                </Grid.Column>
                <Grid.Column width={16}> 
                    {addPhotoMode ? (
                        <PhotoUploadWidget uploadPhoto={handlePhotoUpload} loading={uploading}/>
                    ) : (
                        <Card.Group itemsPerRow={5}>
                            {profile.photos?.map(photo => (
                            <Card key={photo.id}>
                            <Image src={photo.url }/>
                            {isCurrentUser && (
                                <Button.Group fluid widths={2}>
                                    <Button
                                        basic
                                        color='green'
                                        content='Main'
                                        name={'main' + photo.id}
                                        loading={target === 'main' + photo.id && loading}
                                        onClick={e => handleSetMainPhoto(photo, e)} 
                                    />
                                    <Button basic color='red' icon='trash'
                                        loading={target === photo.id && loading} 
                                        onClick={e => handleDeletePhoto(photo, e)}
                                        name={photo.id}
                                        disabled={photo.isMain}
                                    />
                                </Button.Group>
                            )}
                        </Card>
                ))}
            </Card.Group>
                    )}
                </Grid.Column>
            </Grid>
            <Header icon='image' content='Photos'/>
            <Card.Group itemsPerRow={5}>
                {profile.photos?.map(photo => (
                <Card key={photo.id}>
                    <Image src={photo.url }/>
                </Card>
                ))}
            </Card.Group>
        </Tab.Pane>
    )
})