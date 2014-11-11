<?php /* Smarty version 2.6.18, created on 2013-12-05 11:33:08
         compiled from Dataface_DeleteForm.html */ ?>
<?php require_once(SMARTY_CORE_DIR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('block', 'define_slot', 'Dataface_DeleteForm.html', 21, false),array('block', 'translate', 'Dataface_DeleteForm.html', 22, false),array('function', 'block', 'Dataface_DeleteForm.html', 25, false),)), $this); ?>
<h2>
<?php $this->_tag_stack[] = array('define_slot', array('name' => 'delete_form_heading')); $_block_repeat=true;$this->_plugins['block']['define_slot'][0][0]->define_slot($this->_tag_stack[count($this->_tag_stack)-1][1], null, $this, $_block_repeat);while ($_block_repeat) { ob_start(); ?>
	<?php $this->_tag_stack[] = array('translate', array('id' => "templates.Dataface_DeleteForm.DELETE_RECORDS")); $_block_repeat=true;$this->_plugins['block']['translate'][0][0]->translate($this->_tag_stack[count($this->_tag_stack)-1][1], null, $this, $_block_repeat);while ($_block_repeat) { ob_start(); ?>Delete Records<?php $_block_content = ob_get_contents(); ob_end_clean(); $_block_repeat=false;echo $this->_plugins['block']['translate'][0][0]->translate($this->_tag_stack[count($this->_tag_stack)-1][1], $_block_content, $this, $_block_repeat); }  array_pop($this->_tag_stack); ?>
<?php $_block_content = ob_get_contents(); ob_end_clean(); $_block_repeat=false;echo $this->_plugins['block']['define_slot'][0][0]->define_slot($this->_tag_stack[count($this->_tag_stack)-1][1], $_block_content, $this, $_block_repeat); }  array_pop($this->_tag_stack); ?>	
</h2>
<?php echo $this->_plugins['function']['block'][0][0]->block(array('name' => 'before_delete_form_message'), $this);?>

<?php $this->_tag_stack[] = array('define_slot', array('name' => 'delete_form_message')); $_block_repeat=true;$this->_plugins['block']['define_slot'][0][0]->define_slot($this->_tag_stack[count($this->_tag_stack)-1][1], null, $this, $_block_repeat);while ($_block_repeat) { ob_start(); ?><?php echo $this->_tpl_vars['msg']; ?>
<?php $_block_content = ob_get_contents(); ob_end_clean(); $_block_repeat=false;echo $this->_plugins['block']['define_slot'][0][0]->define_slot($this->_tag_stack[count($this->_tag_stack)-1][1], $_block_content, $this, $_block_repeat); }  array_pop($this->_tag_stack); ?>
<?php echo $this->_plugins['function']['block'][0][0]->block(array('name' => 'after_delete_form_message'), $this);?>

<?php echo $this->_tpl_vars['form']; ?>
