import React from 'react';
import { observer } from 'mobx-react-lite';
import { Form, Button, Header} from 'semantic-ui-react';
import { ErrorMessage, Formik } from 'formik';
import MyTextInput from '../../app/common/form/MyTextInput';
import * as Yup from 'yup';
import ValidationErrors from "../errors/ValidationErrors";
import { useStore } from '../../app/stores/store';

export default observer(function ProfileEditForm() {
  const {profileStore} = useStore();

return (
  <Formik
  initialValues={{displayName: '', bio: '', error: null}}
  onSubmit={(values, {setErrors}) => profileStore.updateProfile(values).catch(error => 
  setErrors({error}))}
  validationSchema={Yup.object({
      displayName: Yup.string().required(),
      bio: Yup.string().required(),
  })}
  >
{({handleSubmit, isSubmitting, errors, isValid, dirty}) => (
  <Form className="ui form error" onSubmit={handleSubmit} autoComplete='off'>
      <Header as='h2' content='Sign Up to Reactivities' color='teal' textAlign='center'/>
      <MyTextInput name='displayName' placeholder='Display Name'/>
      <MyTextInput name='bio' placeholder='Bio'/>
      <ErrorMessage 
          name='error' render={() => <ValidationErrors errors={errors.error} /> }
      />
      <Button disabled={!isValid || !dirty || isSubmitting} positive content='Update Profile' type='submit' fluid />
  </Form>
)}
</Formik>
);
 
});
