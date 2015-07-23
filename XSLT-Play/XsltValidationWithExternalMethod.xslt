<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" 
  xmlns:func="urn:actl-xslt"
  exclude-result-prefixes="msxsl">
  
  <xsl:output method="xml" indent="yes"/>


<xsl:template match="root">
  <root>
  <xsl:for-each select="User">

    <output>
    <xsl:if test="not(UserName)" >
      <error>
        <errmsg>UserName Tag Missing</errmsg>
        <errcode>501</errcode>
    </error>
    </xsl:if>

      <xsl:if test="UserName=''">
        <error>
          <errmsg>UserName has no value</errmsg>
          <errcode>501</errcode>
        </error>
      </xsl:if>
      <xsl:value-of select="func:validateUser(UserName, Password)"/>
    </output>
  
  
  </xsl:for-each>
</root>
</xsl:template>
</xsl:stylesheet>
